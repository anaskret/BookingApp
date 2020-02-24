using Booking.App.Contracts.Requests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Converters.Interfaces;
using Booking.Services.Interfaces;
using BookingApp.Models;
using BookingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booking.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventConverter _eventConverter;

        public EventService(IEventConverter eventConverter, IEventRepository eventRepository)
        {
            _eventConverter = eventConverter;
            _eventRepository = eventRepository;
        }
        public IEnumerable<GetEventRequest> GetAllEvents()
        {
            return _eventRepository.GetAllEvents().Select(c => _eventConverter.FromEventToGetEventRequest(c));
        }

        public GetEventRequest GetEventById(int eventId)
        {
            var eventById = _eventConverter.FromEventToGetEventRequest(_eventRepository.GetEventById(eventId));

            return eventById;
        }

        public Event CreateEvent(CreateEventRequest eventRequest)
        {
            var createEvent = _eventConverter.FromCreateEventRequestToEvent(eventRequest);

            _eventRepository.CreateEvent(createEvent);

            return createEvent;
        }

        public bool UpdateEvent(int eventId,UpdateEventRequest request)
        {
            var updateEvent = _eventConverter.FromUpdateEventRequestToEvent(eventId, request);

            var updated = _eventRepository.UpdateEvent(updateEvent);

            return updated;
        }

        public bool DeleteEvent(int eventId)
        {
            var deleted = _eventRepository.DeleteEvent(eventId);

            return deleted;
        }

        

        
    }
}
