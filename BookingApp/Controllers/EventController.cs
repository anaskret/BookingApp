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
        public IActionResult Get()
        {
            return Ok(_eventService.GetEvents());
        }
    }
}
