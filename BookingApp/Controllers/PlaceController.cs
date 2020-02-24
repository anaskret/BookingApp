using Booking.Services.Interfaces;
using BookingApp.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.App.Controllers
{
    public class PlaceController: Controller
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet(ApiRoutes.Places.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_placeService.GetAllPlaces());
        }

        [HttpGet(ApiRoutes.Places.Get)]
        public IActionResult Get([FromRoute] int placeId)
        {
            var place = _placeService.GetPlaceById(placeId);

            if (place == null)
                return NotFound();

            return Ok(place);
        }
    }
}
