using Booking.App.Contracts.Requests;
using BookingApp.Contracts;
using BookingApp.Services.Interfaces;
using Booking.Models.Converters.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Booking.App.Contracts.Responses;

namespace BookingApp.Controllers
{
    public class EventController: Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventConverter _eventConverter;

        public EventController(IEventRepository eventRepository, IEventConverter eventConverter)
        {
            _eventRepository = eventRepository;
            _eventConverter = eventConverter;
        }

        [HttpGet(ApiRoutes.Events.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_eventRepository.GetAllEvents());
        }

        [HttpGet(ApiRoutes.Events.Get)]
        public IActionResult Get([FromRoute] int eventId)
        {
            var eventById = _eventConverter.FromEventToGetEventRequest(_eventRepository.GetEventById(eventId));
                
            if(eventById == null)
                return NotFound();

            return Ok(eventById);
        }

        [HttpPost(ApiRoutes.Events.Create)]
        public IActionResult Create([FromBody] CreateEventRequest eventRequest)
        {
            var createEvent = _eventConverter.FromCreateEventRequestToEvent(eventRequest);

            _eventRepository.CreateEvent(createEvent);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Events.Get.Replace("{postId}", createEvent.EventId.ToString());
            _ = new EventResponse { EventId = createEvent.EventId };

            return Created(locationUri, createEvent);
        }

        [HttpPut(ApiRoutes.Events.Update)]
        public IActionResult Update([FromRoute] int eventId, [FromBody] UpdateEventRequest request)
        {
            var updateEvent = _eventConverter.FromUpdateEventRequestToEvent(request);

            var updated = _eventRepository.UpdateEvent(updateEvent);

            if (updated)
                return Ok(updateEvent);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Events.Delete)]
        public IActionResult Delete([FromRoute] int eventId)
        {
            var deleted = _eventRepository.DeleteEvent(eventId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }

}
