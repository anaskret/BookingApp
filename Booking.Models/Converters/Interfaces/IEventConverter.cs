using Booking.App.Contracts.Requests;
using Booking.Models.Contracts.Requests.GetRequests;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Converters.Interfaces
{
    public interface IEventConverter
    {
        Event FromCreateEventRequestToEvent(CreateEventRequest createEventRequest);
        GetEventRequest FromEventToGetEventRequest(Event events);
        Event FromUpdateEventRequestToEvent(int eventId, UpdateEventRequest updateEventRequest);
    }
}
