using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Converters.Interfaces;
using Booking.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Converters
{
    public class TicketConverter : ITicketConverter
    {
        public Ticket CreateTicketRequestToTicket(CreateTicketRequest ticket)
        {
            return new Ticket
            {
                Email = ticket.Email,
                StatusId = ticket.StatusId
            };
        }

        public GetTicketRequest TicketToGetTicketRequest(Ticket ticket)
        {
            return new GetTicketRequest
            {
                TicketId = ticket.TicketId,
                Email = ticket.Email,
                BookingDate = ticket.BookingDate,
                StatusId = ticket.StatusId,
                SeatCoordinates = ticket.SeatCoordinates(),
                EventDate = ticket.EventDate(),
                Price = ticket.Price()
            };
        }
    }
}
