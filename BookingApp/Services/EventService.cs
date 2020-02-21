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
    public class EventService : IEventService
    {
        private readonly BookingAppContext _dataContext;

        public EventService(BookingAppContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Event> GetAllEvents()
        {
            return _dataContext.Events.ToList();
        }

        public Event GetEventById(int eventId)
        {
            return _dataContext.Events.SingleOrDefault(x => x.EventId == eventId);
        }

        public bool CreateEvent(Event eventCreate)
        {
            _dataContext.Events.Add(eventCreate);

            var created = _dataContext.SaveChanges();

            return created > 0;
        }

        public bool UpdateEvent(Event eventUpdate)
        {
            _dataContext.Events.Update(eventUpdate);

            var updated = _dataContext.SaveChanges();

            return updated > 0;
        }
    }
}
