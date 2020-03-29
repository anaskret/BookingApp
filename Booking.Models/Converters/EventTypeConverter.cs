using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Converters.Interfaces;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Converters
{
    public class EventTypeConverter : IEventTypeConverter
    {
        public GetEventTypeRequest EventTypeToGetEventTypeRequest(EventType eventType)
        {
            return new GetEventTypeRequest
            {
                TypeId = eventType.TypeId,
                Type = eventType.Type
            };
        }
    }
}
