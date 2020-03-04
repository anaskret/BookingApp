using Booking.App.Contracts.Requests;
using Booking.Models.Contracts.Requests.GetRequests;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<GetEventRequest>> GetAllEvents();
        Task<GetEventRequest> GetEventById(int eventId);
        Task<Event> CreateEvent(CreateEventRequest createEventRequest);
        Task<bool> UpdateEvent(int eventId, UpdateEventRequest request);
        Task<bool> DeleteEvent(int eventId);
        IEnumerable<GetEventRequest> FilterEvents(Dictionary<string, string> stringDictionary, Dictionary<string, int[]> intDictionary, DateTime[] date);
    }
}
