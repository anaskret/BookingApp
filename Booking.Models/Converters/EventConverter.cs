using Booking.App.Contracts.Requests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Converters.Interfaces;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Converters
{
    public class EventConverter : IEventConverter
    {
        public Event CreateEventRequestToEvent(CreateEventRequest createEventRequest)
        {
            return new Event
            {
                Name = createEventRequest.Name,
                Date = createEventRequest.Date,
                Description = createEventRequest.Description,
                PlaceId = createEventRequest.PlaceId,
                TypeId = createEventRequest.TypeId
            };

        }

        public GetEventRequest EventToGetEventRequest(Event events)
        {
            if (events == null)
                return null;
            return new GetEventRequest
            {
                EventId = events.EventId,
                Name = events.Name,
                Date = events.Date,
                Description = events.Description,
                PlaceId = events.PlaceId,
                TypeId = events.TypeId,
                AvailableSeats = events.AvailableSeats,
                NumberOfSeats = events.NumberOfSeats
            };
        }
        
        public GetEventByIdRequest EventToGetEventByIdRequest(Event events, List<GetSeatTypesCountRequest> getSeatTypes, List<GetSectorPricesRequest> getSectorPrices)
        {
            if (events == null)
                return null;
            return new GetEventByIdRequest
            {
                EventId = events.EventId,
                Name = events.Name,
                Date = events.Date,
                Description = events.Description,
                PlaceId = events.PlaceId,
                TypeId = events.TypeId,
                AvailableSeats = events.AvailableSeats,
                NumberOfSeats = events.NumberOfSeats,
                SeatTypesCount = getSeatTypes,
                SectorPrices = getSectorPrices
            };
        }

        public Event UpdateEventRequestToEvent(int eventId, UpdateEventRequest updateEventRequest)
        {
            return new Event
            {
                EventId = eventId,
                Name = updateEventRequest.Name,
                Date = updateEventRequest.Date,
                Description = updateEventRequest.Description,
                PlaceId = updateEventRequest.PlaceId,
                TypeId = updateEventRequest.TypeId,
            };
        }
    }
}
