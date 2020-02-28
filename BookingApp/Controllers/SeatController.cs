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
    public class SeatController: Controller
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet(ApiRoutes.Seats.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _seatService.GetAllSeats());
        }

        [HttpGet(ApiRoutes.Seats.Get)]
        public async Task<IActionResult> Get([FromRoute] int seatId)
        {
            return Ok(await _seatService.GetSeatById(seatId));
        }

        [HttpPost(ApiRoutes.Seats.Create)]
        public async Task<IActionResult> Create([FromBody] CreateSeatRequest createSeat)
        {
            var seat = await _seatService.CreateSeat(createSeat);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Seats.Get.Replace("{postId}", seat.SeatId.ToString());

            return Created(locationUri, seat);
        }

        [HttpPut(ApiRoutes.Seats.Update)]
        public async Task<IActionResult> Update([FromRoute] int seatId, [FromBody] UpdateSeatRequest updateSeat)
        {
            var updated = await _seatService.UpdateSeat(updateSeat, seatId);

            if (updated)
                return Ok(updated);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Seats.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int seatId)
        {
            var deleted = await _seatService.DeleteSeat(seatId);

            if (deleted)
                return Ok("Succesfuly deleted");

            return NotFound();
        }
    }
}
