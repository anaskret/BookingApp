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

        public List<Event> GetEvents()
        {
            return _dataContext.Events.ToList();
        }

    }
}
