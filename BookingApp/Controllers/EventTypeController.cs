using Booking.Services.Interfaces;
using BookingApp.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.App.Controllers
{
    public class EventTypeController: Controller
    {
        private readonly IEventTypeService _eventTypeService;
        public EventTypeController(IEventTypeService eventTypeService)
        {
            _eventTypeService = eventTypeService;
        }

        [HttpGet(ApiRoutes.EventTypes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _eventTypeService.GetEventTypes());
        }
    }
}
