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
            var eventById = await _dataContext.Events.FirstOrDefaultAsync(x => x.EventId == eventId);
            
            if (eventById == null)
                throw new NullReferenceException("Selected event doesn't exist");
            
            eventById.AvailableSeats = FilterTools.AvailableSeatCount(eventById.EventId, _dataContext);         //Update available seats
            _dataContext.Events.Update(eventById);
            _dataContext.SaveChanges();


            return eventById;
        }

        public async Task<bool> CreateEvent(Event eventCreate)
        {
            var places = _dataContext.Places.Where(t => t.PlaceId == eventCreate.PlaceId).FirstOrDefault();
            if (eventCreate.PlaceId < 1 || places == null)
                throw new NullReferenceException("Selected Place doesn't exist");

            var types = _dataContext.EventTypes.Where(et => et.TypeId == eventCreate.TypeId).FirstOrDefault();
            if (eventCreate.TypeId < 1 || types == null)
                throw new NullReferenceException("Selected Type doesn't exist");

            eventCreate.NumberOfSeats = eventCreate.Place.MaximumCapacity;
            eventCreate.AvailableSeats = eventCreate.SeatStatuses.Where(x => x.Available == true).Count();

            await _dataContext.Events.AddAsync(eventCreate);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateEvent(Event eventUpdate)
        {
            var events = _dataContext.Events.Where(e => e.EventId == eventUpdate.EventId).FirstOrDefault();
            if (events == null)
                throw new NullReferenceException("Selected event doesn't exist");

            var places = _dataContext.Places.Where(p => p.PlaceId == eventUpdate.PlaceId).FirstOrDefault();
            if (places == null)
                throw new NullReferenceException("Selected place doesn't exist");

            var types = _dataContext.EventTypes.Where(et => et.TypeId == eventUpdate.TypeId).FirstOrDefault();
            if (types == null)
                throw new NullReferenceException("Selected type doesn't exist");

            _dataContext.Events.Update(eventUpdate);

            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            var events = _dataContext.Events.Where(e => e.EventId == eventId).FirstOrDefault();

            if (events == null)
                return false;

            var deleteEvent = await GetEventById(eventId);

            _dataContext.Events.Remove(deleteEvent);
            
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<List<Event>> GetAllOrFilterEvent(FilterEventsRequest filterEvents)
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

            if(queryCount == 0)
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

            foreach(var item in group)
            {
                if (item.Count() == queryCount)
                    result.Add(item.Key);
            }

            return result.ToList();
        }

        public async Task<List<GetSeatTypesCountRequest>> GetNumberOfSeatsByType(int placeId)
        {
            var getTypes = await _dataContext.Seats.Where(x => x.PlaceId == placeId).ToListAsync();
            var groupTypes = getTypes.GroupBy(i => i.TypeId);

            var typesList = new List<GetSeatTypesCountRequest>();

            foreach (var item in groupTypes)
            {
                var type = _dataContext.SeatTypes.SingleOrDefault(x => x.TypeId == item.ElementAt(item.Key).TypeId);
                var price = _dataContext.SectorPrices.SingleOrDefault(x => x.SectorNumber == item.ElementAt(item.Key).SectorNumber);

                var seatType = new GetSeatTypesCountRequest { 
                    SeatType = type.Type,
                    NumberOfSeatsByType = item.Count()
                };

                typesList.Add(seatType);
            }

            return typesList;
        }

        public async Task<List<SectorPrice>> GetSectorPrices(int eventId)
        {
            return await _dataContext.SectorPrices.Where(sp => sp.EventId == eventId).ToListAsync();
        }
    }
}
