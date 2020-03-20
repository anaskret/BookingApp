using BookingApp.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Booking.Services.Interfaces;
using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Models;
using Booking.Models.Contracts.Requests.GetRequests;

namespace Booking.App.Controllers
{
    public class TicketController: Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet(ApiRoutes.Tickets.Get)]
        public async Task<IActionResult> GetById([FromRoute] Guid ticketId)
        {
            GetTicketRequest ticket;
            try
            {
                ticket = await _ticketService.GetTicketById(ticketId);
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }

            return Ok(ticket);
        }

        [HttpPost(ApiRoutes.Tickets.Create)]
        public async Task<IActionResult> Create([FromBody] CreateTicketRequest createTicket)
        {
            Ticket created;
            try
            {
                 created = await _ticketService.CreateTicket(createTicket);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok(created);
        }
    }
}
