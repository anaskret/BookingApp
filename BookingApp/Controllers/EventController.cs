using Booking.App.Contracts.Requests;
using BookingApp.Contracts;
using BookingApp.Services.Interfaces;
using Booking.Models.Converters.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Booking.App.Contracts.Responses;
using Booking.Services.Interfaces;

namespace BookingApp.Controllers
{
    public class EventController: Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet(ApiRoutes.Events.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_eventService.GetAllEvents());
        }

        [HttpGet(ApiRoutes.Events.Get)]
        public IActionResult Get([FromRoute] int eventId)
        {
            var events = _eventService.GetEventById(eventId);

            if (events == null)
                return NotFound();

            return Ok(events);
        }

        [HttpPost(ApiRoutes.Events.Create)]
        public IActionResult Create([FromBody] CreateEventRequest eventRequest)
        {
            var createEvent = _eventService.CreateEvent(eventRequest);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Events.Get.Replace("{postId}", createEvent.EventId.ToString());
            _ = new EventResponse { EventId = createEvent.EventId };

            return Created(locationUri, createEvent);
        }

        [HttpPut(ApiRoutes.Events.Update)]
        public IActionResult Update([FromRoute] int eventId, [FromBody] UpdateEventRequest request)
        {
            if (_eventService.UpdateEvent(eventId, request))
                return Ok();

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Events.Delete)]
        public IActionResult Delete([FromRoute] int eventId)
        {
            if (_eventService.DeleteEvent(eventId))
                return NoContent();

            return NotFound();
        }
    }

}
