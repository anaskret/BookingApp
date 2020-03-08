using Booking.Models.Contracts.Requests.FilterRequests;
using BookingApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Services.Interfaces
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllEvents();
        Task<Event> GetEventById(int eventId);
        Task<bool> CreateEvent(Event eventCreate);
        Task<bool> UpdateEvent(Event eventUpdate);
        Task<bool> DeleteEvent(int eventId);
        List<Event> FilterEvent(FilterEventsRequest filterEvents);
    }
}
