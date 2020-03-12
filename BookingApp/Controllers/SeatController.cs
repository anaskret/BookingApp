using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.FilterRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Contracts.Requests.UpdateRequests;
using Booking.Services.Interfaces;
using BookingApp.Contracts;
using BookingApp.Models;
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
        public async Task<IActionResult> GetAllOrFilter([FromQuery] FilterSeatsRequest filterSeats)
        {
            return Ok(await _seatService.GetSeats(filterSeats));
        }

        [HttpGet(ApiRoutes.Seats.Get)]
        public async Task<IActionResult> Get([FromRoute] int seatId)
        {
            GetSeatRequest seat;
            try
            {
                seat = await _seatService.GetSeatById(seatId);
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }

            return Ok(seat);
        }

        [HttpPost(ApiRoutes.Seats.Create)]
        public async Task<IActionResult> Create([FromBody] CreateSeatRequest createSeat)
        {
            Seat seat;
            try
            {
                seat = await _seatService.CreateSeat(createSeat);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

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
