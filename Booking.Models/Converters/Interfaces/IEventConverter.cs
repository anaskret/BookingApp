using Booking.App.Contracts.Requests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Contracts.Responses;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Converters.Interfaces
{
    public interface IEventConverter
    {
        Event CreateEventRequestToEvent(CreateEventRequest createEventRequest);
        GetEventRequest EventToGetEventRequest(Event events);
        GetEventByIdRequest EventToGetEventByIdRequest(Event events, List<GetSeatTypesCountResponse> getSeatTypes);
        Event UpdateEventRequestToEvent(int eventId, UpdateEventRequest updateEventRequest);
    }
}
