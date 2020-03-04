using Booking.App.Contracts.Requests;
using BookingApp.Contracts;
using BookingApp.Services.Interfaces;
using Booking.Models.Converters.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Booking.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Booking.Models.Contracts.Requests.FilterRequests;
using System;

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


            var intDictionary = new Dictionary<string, int[]>();

            int[] eventIdArray= { filterEvents.MinEventId, filterEvents.MaxEventId };
            if (filterEvents.MinEventId > 0 && filterEvents.MaxEventId > filterEvents.MinEventId)
                intDictionary.Add("EventId", eventIdArray);

            int[] placeIdArray = { filterEvents.MinPlaceId, filterEvents.MaxPlaceId};
            if (filterEvents.MinPlaceId > 0 && filterEvents.MaxPlaceId > filterEvents.MinPlaceId)
                intDictionary.Add("Name", placeIdArray);

            DateTime[] dateArray = null;
            if (filterEvents.MinDate.Year > 1970 && filterEvents.MaxDate.Year > 1970)
            {
                dateArray[0] = filterEvents.MinDate; 
                dateArray[1] = filterEvents.MaxDate;
            }
            

            var filterdEvents = _eventService.FilterEvents(stringDictionary, intDictionary, dateArray);

            if (filterdEvents == null)
                return NotFound();

            return Ok(filterdEvents);
        }
    }

}
