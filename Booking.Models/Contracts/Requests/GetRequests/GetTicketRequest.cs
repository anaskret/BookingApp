using Booking.Models.Contracts.Requests.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.GetRequests
{
    public class GetTicketRequest: TicketRequest
    {
        public Guid BookingId { get; set; }
        public string SeatCoordinates { get; set; }
        public DateTime EventDate { get; set; }
        public decimal Price { get; set; }
    }
}
