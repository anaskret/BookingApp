using Booking.Models.Contracts.Requests.GetRequests;
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

        public List<Event> FilterEvent(Dictionary<string, string> stringDictionary, Dictionary<string, int> intDictionary, DateTime date)
        {
            var events = new List<Event>();

            foreach(var item in intDictionary)
            {
                switch(item.Key)
                {
                    case "EventId":
                        var eventId = _dataContext.Events.Where(c => c.EventId == item.Value);
                        foreach (var id in eventId)
                            if (!events.Contains(id))
                                events.Add(id);
                        break;
                    case "PlaceId":
                        var placeId = _dataContext.Events.Where(c => c.PlaceId == item.Value);
                        foreach (var id in placeId)
                            if (!events.Contains(id))
                                events.Add(id);
                        break;
                }
            }

            foreach(var item in stringDictionary)
            {
                switch(item.Key)
                {
                    case "Name":
                        var eventName = _dataContext.Events.Where(c =>  c.Name == item.Value);
                        foreach (var name in eventName) 
                            if(!events.Contains(name))
                                events.Add(name);
                        break;
                    case "Description":
                        var eventDescription = _dataContext.Events.Where(c => c.Description == item.Value);
                        foreach (var description in eventDescription)
                            if (!events.Contains(description))
                                events.Add(description);
                        break;
                }
            }

            
            var eventDate = _dataContext.Events.Where(c => c.Date == date);
            foreach (var item in eventDate)
                if (!events.Contains(item))
                    events.Add(item);
            

            return events;
        }
    }
}
