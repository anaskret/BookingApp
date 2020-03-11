using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.FilterRequests;
using Booking.Models.Contracts.Requests.GetRequests;
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
        public async Task<IActionResult> GetAllOrFilter([FromQuery] FilterPlacesRequest filter)
        {
            return Ok(await _placeService.GetPlaces(filter));
        }

        [HttpGet(ApiRoutes.Places.Get)]
        public async Task<IActionResult> Get([FromRoute] int placeId)
        {
            GetPlaceRequest place;
            try
            {
                place = await _placeService.GetPlaceById(placeId);
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }

            return Ok(place);
        }

        [HttpPost(ApiRoutes.Places.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePlaceRequest createPlaceRequest)
        {
            var place = await _placeService.CreatePlace(createPlaceRequest);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Places.Get.Replace("{postId}", place.PlaceId.ToString());

            return Created(locationUri, place);
        }

        [HttpPut(ApiRoutes.Places.Update)]
        public async Task<IActionResult> Update([FromRoute] int placeId, [FromBody] UpdatePlaceRequest updatePlaceRequest)
        {
            bool place;
            try
            {
                place = await _placeService.UpdatePlace(placeId, updatePlaceRequest);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            if (place)
                return Ok();

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Places.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int placeId)
        {
            var place = await _placeService.DeletePlace(placeId);

            if (!place)
                return NotFound();

            return Ok(place);
        }
    }
}
