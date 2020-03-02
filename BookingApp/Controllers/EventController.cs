using Booking.App.Contracts.Requests;
using BookingApp.Contracts;
using BookingApp.Services.Interfaces;
using Booking.Models.Converters.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Booking.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Booking.Models.Contracts.Requests.FilterRequests;

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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _eventService.GetAllEvents());
        }

        [HttpGet(ApiRoutes.Events.Get)]
        public async Task<IActionResult> Get([FromRoute] int eventId)
        {
            var events = _eventService.GetEventById(eventId);

            if (events == null)
                return NotFound();

            return Ok(await events);
        }

        [HttpPost(ApiRoutes.Events.Create)]
        public async Task<IActionResult> Create([FromBody] CreateEventRequest eventRequest)
        {
            var createEvent = await _eventService.CreateEvent(eventRequest);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Events.Get.Replace("{postId}", createEvent.EventId.ToString());

            return Created(locationUri, createEvent);
        }

        [HttpPut(ApiRoutes.Events.Update)]
        public async Task<IActionResult> Update([FromRoute] int eventId, [FromBody] UpdateEventRequest request)
        {
            if (await _eventService.UpdateEvent(eventId, request))
                return Ok();

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Events.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int eventId)
        {
            if (await _eventService.DeleteEvent(eventId))
                return NoContent();

            return NotFound();
        }

        [HttpGet(ApiRoutes.Events.Filter)]
        public IActionResult Filter([FromQuery] FilterEventsRequest filterEvents)
        {
            var stringDictionary = new Dictionary<string, string>();

            if (filterEvents.Name != null)
                stringDictionary.Add("Name", filterEvents.Name);
            if (filterEvents.Description != null)
                stringDictionary.Add("Description", filterEvents.Description);


            var intDictionary = new Dictionary<string, int>();

            if (filterEvents.EventId > 1)
                intDictionary.Add("EventId", filterEvents.EventId);
            if (filterEvents.PlaceId > 1)
                intDictionary.Add("Name", filterEvents.PlaceId);

            var filterdEvents = _eventService.FilterEvents(stringDictionary, intDictionary);

            if (filterdEvents == null)
                return NotFound();

            return Ok(filterdEvents);
        }
    }

}
