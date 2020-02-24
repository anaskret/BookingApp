using Booking.App.Contracts.Requests;
using Booking.Models.Contracts.Requests.GetRequests;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Services.Interfaces
{
    public interface IEventService
    {
        public IEnumerable<GetEventRequest> GetAllEvents();
        public GetEventRequest GetEventById(int eventId);
        public Event CreateEvent(CreateEventRequest createEventRequest);
        public bool UpdateEvent(int eventId, UpdateEventRequest request);
        public bool DeleteEvent(int eventId);
    }
}
