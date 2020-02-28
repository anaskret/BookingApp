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
        public Task<IEnumerable<GetEventRequest>> GetAllEvents();
        public Task<GetEventRequest> GetEventById(int eventId);
        public Task<Event> CreateEvent(CreateEventRequest createEventRequest);
        public Task<bool> UpdateEvent(int eventId, UpdateEventRequest request);
        public Task<bool> DeleteEvent(int eventId);
    }
}
