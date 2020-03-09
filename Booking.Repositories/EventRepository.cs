using Booking.Models.Contracts.Requests.FilterRequests;
using Booking.Repositories.Tools;
using BookingApp.Data;
using BookingApp.Models;
using BookingApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            var events = await _dataContext.Events.ToListAsync();

            foreach (var item in events)
            {
                item.AvailableSeats = FilterTools.AvailableSeatCount(item.EventId, _dataContext);
                _dataContext.Events.Update(item);
            }

            _dataContext.SaveChanges();

            return events;
        }

        public async Task<Event> GetEventById(int eventId)
        {
            var eventById = await _dataContext.Events.SingleOrDefaultAsync(x => x.EventId == eventId);
            
            eventById.AvailableSeats = FilterTools.AvailableSeatCount(eventById.EventId, _dataContext);

            _dataContext.Events.Update(eventById);

            _dataContext.SaveChanges();

            return eventById;
        }

        public async Task<bool> CreateEvent(Event eventCreate)
        {
            var place = _dataContext.Places.SingleOrDefault(x => x.PlaceId == eventCreate.PlaceId);
            eventCreate.NumberOfSeats = place.MaximumCapacity;
            eventCreate.AvailableSeats = _dataContext.SeatStatuses.Select(x => x.Available == false && x.EventId == eventCreate.EventId).Count();

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
            var duplicateEvents = new List<Event>();
            int queryCount = 0;

            if (FilterTools.AreIntsCorrect(filterEvents.MinEventId, filterEvents.MaxEventId))
            { 
                var eventId = _dataContext.Events.Where(c => c.EventId >= filterEvents.MinEventId
                && c.EventId <= filterEvents.MaxEventId);
                foreach (var id in eventId)
                    duplicateEvents.Add(id);
                queryCount++;
            }

            if (FilterTools.AreIntsCorrect(filterEvents.MinPlaceId, filterEvents.MaxPlaceId))
            { var placeId = _dataContext.Events.Where(c => c.PlaceId >= filterEvents.MinPlaceId
                && c.PlaceId <= filterEvents.MaxPlaceId);
                foreach (var id in placeId)
                    duplicateEvents.Add(id);
                queryCount++;
            }

            if (FilterTools.AreIntsCorrect(filterEvents.MinTypeId, filterEvents.MaxTypeId))
            {
                var typeId = _dataContext.Events.Where(c => c.PlaceId >= filterEvents.MinTypeId
                && c.PlaceId <= filterEvents.MaxTypeId);
                foreach (var id in typeId)
                    duplicateEvents.Add(id);
                queryCount++;
            }

            if(filterEvents.Name != null)
            { 
                var eventName = _dataContext.Events.Where(c => c.Name == filterEvents.Name);
                foreach (var name in eventName)
                    duplicateEvents.Add(name);
                queryCount++;
            }
            if (filterEvents.Description != null)
            {
                var eventDescription = _dataContext.Events.Where(c => c.Description == filterEvents.Description);
                foreach (var description in eventDescription)
                    duplicateEvents.Add(description);
                queryCount++;
            }        
            if (FilterTools.AreIntsCorrect(filterEvents.MinDate?.Year, filterEvents.MaxDate?.Year))
            {
                var eventDate = _dataContext.Events.Where(c => c.Date >= filterEvents.MinDate
                && c.Date <= filterEvents.MaxDate);
                foreach (var item in eventDate)
                    duplicateEvents.Add(item);
                queryCount++;
            }

            var result = new List<Event>();
            var group = duplicateEvents.GroupBy(i => i);

            foreach(var item in group)
            {
                if (item.Count() == queryCount)
                    result.Add(item.Key);
            }

            return result.ToList();
        }

        /*public SeatCountResponse SeatCount(int eventId)
        {
            var response = new SeatCountResponse
            {
                
            };

            return response;
        }*/
    }
}
