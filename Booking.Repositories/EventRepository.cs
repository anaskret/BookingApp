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
    }
}
