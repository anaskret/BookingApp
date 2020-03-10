using Booking.App.Contracts.Requests;
using Booking.Models.Contracts.Requests.FilterRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Contracts.Responses;
using Booking.Models.Converters.Interfaces;
using Booking.Services.Interfaces;
using BookingApp.Models;
using BookingApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IEnumerable<GetEventRequest>> GetEvents(FilterEventsRequest filterEvents = null)
        {
            var events = await _eventRepository.GetAllOrFilterEvent(filterEvents);
            
            return events.Select(c => _eventConverter.EventToGetEventRequest(c));
        }

        public async Task<GetEventByIdRequest> GetEventById(int eventId)
        {
            var eventById = await _eventRepository.GetEventById(eventId);
            var types = await _eventRepository.GetNumberOfSeatsByType(eventById.PlaceId);
            var convertedEvent = _eventConverter.EventToGetEventByIdRequest(eventById, types);

            return convertedEvent;
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

        public async Task<List<GetSeatTypesCountResponse>> GetNumberOfSeatsByType(int eventId)
        {
            return await _eventRepository.GetNumberOfSeatsByType(eventId);
        }
    }
}
