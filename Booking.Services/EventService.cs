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
using System.Threading.Tasks;

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
        public async Task<IEnumerable<GetEventRequest>> GetAllEvents()
        {
            var events = await _eventRepository.GetAllEvents();

            return events.Select(c => _eventConverter.EventToGetEventRequest(c));
        }

        public async Task<GetEventRequest> GetEventById(int eventId)
        {
            var eventById = _eventConverter.EventToGetEventRequest(await _eventRepository.GetEventById(eventId));

            return eventById;
        }

        public async Task<Event> CreateEvent(CreateEventRequest eventRequest)
        {
            var createEvent = _eventConverter.CreateEventRequestToEvent(eventRequest);

            await _eventRepository.CreateEvent(createEvent);

            return createEvent;
        }

        public async Task<bool> UpdateEvent(int eventId,UpdateEventRequest request)
        {
            var updateEvent = _eventConverter.UpdateEventRequestToEvent(eventId, request);

            var updated = await _eventRepository.UpdateEvent(updateEvent);

            return updated;
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            var deleted = await _eventRepository.DeleteEvent(eventId);

            return deleted;
        }

        public IEnumerable<GetEventRequest> FilterEvents(Dictionary<string, string> stringDictionary, Dictionary<string, int[]> intDictionary, DateTime date)
        {
            var events = _eventRepository.FilterEvent(stringDictionary, intDictionary, date);

            return events.Select(c => _eventConverter.EventToGetEventRequest(c));
        }
    }
}
