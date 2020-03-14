using Booking.App.Contracts.Requests;
using Booking.Models.Contracts.Requests.FilterRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Converters.Interfaces;
using Booking.Services.Interfaces;
using BookingApp.Models;
using BookingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventConverter _eventConverter;
        private readonly ISectorPriceConverter _sectorConverter;

        public EventService(IEventConverter eventConverter, IEventRepository eventRepository, ISectorPriceConverter sectorConverter)
        {
            _eventConverter = eventConverter;
            _eventRepository = eventRepository;
            _sectorConverter = sectorConverter;
        }
        public async Task<ICollection<GetEventRequest>> GetEvents(FilterEventsRequest filterEvents)
        {
            var events = await _eventRepository.GetAllOrFilterEvent(filterEvents);
            
            return events.Select(c => _eventConverter.EventToGetEventRequest(c)).ToList();
        }

        public async Task<GetEventByIdRequest> GetEventById(int eventId)
        {
            Event eventById;
            try
            { 
                eventById = await _eventRepository.GetEventById(eventId); 
            }
            catch
            {
                throw;
            }

            var types = await _eventRepository.GetNumberOfSeatsByType(eventById.PlaceId);

            var sectorPrices = await _eventRepository.GetSectorPrices(eventById.EventId);
            var convertedPrices = sectorPrices.Select(sp => _sectorConverter.SectorPriceToGetSectorPricesResponse(sp)).ToList();

            var convertedEvent = _eventConverter.EventToGetEventByIdRequest(eventById, types, convertedPrices);

            return convertedEvent;
        }

        public async Task<Event> CreateEvent(CreateEventRequest eventRequest)
        {
            Event createEvent;
            try
            {
                createEvent = _eventConverter.CreateEventRequestToEvent(eventRequest);
            }
            catch
            {
                throw;
            }

            await _eventRepository.CreateEvent(createEvent);

            return createEvent;
        }

        public async Task<bool> UpdateEvent(int eventId,UpdateEventRequest request)
        {
            var updateEvent = _eventConverter.UpdateEventRequestToEvent(eventId, request);

            bool updated;
            try
            {
                updated = await _eventRepository.UpdateEvent(updateEvent);
            }
            catch
            {
                throw;
            }
            return updated;
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            var deleted = await _eventRepository.DeleteEvent(eventId);

            return deleted;
        }

        public async Task<List<GetSeatsByType>> GetNumberOfSeatsByType(int eventId)
        {
            return await _eventRepository.GetNumberOfSeatsByType(eventId);
        }
    }
}
