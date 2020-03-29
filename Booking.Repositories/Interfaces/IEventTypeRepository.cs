using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repositories.Interfaces
{
    public interface IEventTypeRepository
    {
        Task<List<EventType>> GetEventTypes();
    }
}
