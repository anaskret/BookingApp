using Booking.Repositories.Interfaces;
using BookingApp.Data;
using BookingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repositories
{
    public class EventTypeRepository : IEventTypeRepository
    {
        private readonly BookingAppContext _dataContext;
        public EventTypeRepository(BookingAppContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<EventType>> GetEventTypes()
        {
            return await _dataContext.EventTypes.ToListAsync();
        }
    }
}
