using Booking.App.Contracts.Requests;
using Booking.App.Contracts.Responses;
using BookingApp.Contracts;
using BookingApp.Models;
using BookingApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var eventById = _eventService.GetEventById(eventId);
                
            if(eventById == null)
                return NotFound();

            return Ok(eventById);
        }

        [HttpPost(ApiRoutes.Events.Create)]
        public IActionResult Create([FromBody] CreateEventRequest eventRequest)
        {
            var createEvent = new Event
            {
                Name = eventRequest.Name,
                Date = eventRequest.Date,
                Description = eventRequest.Description,
                PlaceId = eventRequest.PlaceId,
                TypeId = eventRequest.TypeId
            };

            _eventService.CreateEvent(createEvent);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Events.Get.Replace("{postId}", createEvent.EventId.ToString());
            _ = new EventResponse { EventId = createEvent.EventId };

            return Created(locationUri, createEvent);
        }
    }
}
