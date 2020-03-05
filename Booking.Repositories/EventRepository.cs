using Booking.Models.Contracts.Requests.FilterRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Repositories.Tools;
using BookingApp.Data;
using BookingApp.Models;
using BookingApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Services
{
    public class EventRepository : IEventRepository
    {
        private readonly BookingAppContext _dataContext;

        public EventRepository(BookingAppContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Event>> GetAllEvents()
        {
            return await _dataContext.Events.ToListAsync();
        }

        public async Task<Event> GetEventById(int eventId)
        {
            return await _dataContext.Events.SingleOrDefaultAsync(x => x.EventId == eventId);
        }

        public async Task<bool> CreateEvent(Event eventCreate)
        {
            await _dataContext.Events.AddAsync(eventCreate);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateEvent(Event eventUpdate)
        {
            _dataContext.Events.Update(eventUpdate);

            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            var deleteEvent = await GetEventById(eventId);

            if (deleteEvent == null)
                return false;

            _dataContext.Events.Remove(deleteEvent);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public List<Event> FilterEvent(FilterEventsRequest filterEvents)
        {
            var events = new List<Event>();
            int queryCount = 0;

            if (EventTools.IsIntNotNull(filterEvents.MinEventId, filterEvents.MaxEventId))
            { 
                var eventId = _dataContext.Events.Where(c => c.EventId >= filterEvents.MinEventId
                && c.EventId <= filterEvents.MaxEventId);
                foreach (var id in eventId)
                    events.Add(id);
                queryCount++;
            }

            if (EventTools.IsIntNotNull(filterEvents.MinPlaceId, filterEvents.MaxPlaceId))
            { var placeId = _dataContext.Events.Where(c => c.PlaceId >= filterEvents.MinPlaceId
                && c.PlaceId <= filterEvents.MaxPlaceId);
                foreach (var id in placeId)
                    events.Add(id);
                queryCount++;
            }

            if (EventTools.IsIntNotNull(filterEvents.MinTypeId, filterEvents.MaxTypeId))
            {
                var typeId = _dataContext.Events.Where(c => c.PlaceId >= filterEvents.MinTypeId
                && c.PlaceId <= filterEvents.MaxTypeId);
                foreach (var id in typeId)
                    events.Add(id);
                queryCount++;
            }

            if(filterEvents.Name != null)
            { 
                var eventName = _dataContext.Events.Where(c => c.Name == filterEvents.Name);
                foreach (var name in eventName)
                    events.Add(name);
                queryCount++;
            }
            if (filterEvents.Description != null)
            {
                var eventDescription = _dataContext.Events.Where(c => c.Description == filterEvents.Description);
                foreach (var description in eventDescription)
                    events.Add(description);
                queryCount++;
            }        
            if (EventTools.IsIntNotNull(filterEvents.MinDate.Year, filterEvents.MaxDate.Year))
            {
                var eventDate = _dataContext.Events.Where(c => c.Date >= filterEvents.MinDate
                && c.Date <= filterEvents.MaxDate);
                foreach (var item in eventDate)
                    events.Add(item);
                queryCount++;
            }

            var result = new List<Event>();
            var group = events.GroupBy(i => i);

            foreach(var item in group)
            {
                var cos = item.Count();
                if (item.Count() == queryCount)
                    result.Add(item.Key);
            }

            return result;
        }
    }
}
