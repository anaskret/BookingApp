using Booking.Models.Contracts.Requests.GetRequests;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Services.Interfaces
{
    public interface IEventRepository
    {
        List<Event> GetAllEvents();
        Event GetEventById(int eventId);
        bool CreateEvent(Event eventCreate);
        bool UpdateEvent(Event eventUpdate);
        bool DeleteEvent(int eventId);
    }
}
