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
    }
}
