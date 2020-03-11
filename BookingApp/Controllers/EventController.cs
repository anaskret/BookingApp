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
using Booking.Models.Contracts.Requests.GetRequests;
using BookingApp.Models;

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
        public async Task<IActionResult> GetAllOrFilter([FromQuery] FilterEventsRequest filterEvents)
        {
            return Ok(await _eventService.GetEvents(filterEvents));
        }

        [HttpGet(ApiRoutes.Events.Get)]
        public async Task<IActionResult> Get([FromRoute] int eventId)
        {
            GetEventByIdRequest eventById;
            try
            {
                eventById = await _eventService.GetEventById(eventId);
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }
            return Ok(eventById);
        }

        [HttpPost(ApiRoutes.Events.Create)]
        public async Task<IActionResult> Create([FromBody] CreateEventRequest eventRequest)
        {
            Event createEvent;
            try
            {
                createEvent = await _eventService.CreateEvent(eventRequest);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Events.Get.Replace("{postId}", createEvent.EventId.ToString());

            return Created(locationUri, createEvent);
        }

        [HttpPut(ApiRoutes.Events.Update)]
        public async Task<IActionResult> Update([FromRoute] int eventId, [FromBody] UpdateEventRequest request)
        {
            bool updateEvent;
            try
            {
                updateEvent = await _eventService.UpdateEvent(eventId, request);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            if(updateEvent)
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
    }

}
