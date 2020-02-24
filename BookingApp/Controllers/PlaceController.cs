using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.UpdateRequests;
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

        [HttpPost(ApiRoutes.Places.Create)]
        public IActionResult Create([FromBody] CreatePlaceRequest createPlaceRequest)
        {
            var place = _placeService.CreatePlace(createPlaceRequest);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Events.Get.Replace("{postId}", place.PlaceId.ToString());

            return Created(locationUri, place);
        }

        [HttpPut(ApiRoutes.Places.Update)]
        public IActionResult Update([FromRoute] int placeId, [FromBody] UpdatePlaceRequest updatePlaceRequest)
        {
            var place = _placeService.UpdatePlace(placeId, updatePlaceRequest);

            if (!place)
                return NotFound();

            return Ok(place);
        }

        [HttpDelete(ApiRoutes.Places.Delete)]
        public IActionResult Delete([FromRoute] int placeId)
        {
            var place = _placeService.DeletePlace(placeId);

            if (!place)
                return NotFound();

            return Ok(place);
        }
    }
}
