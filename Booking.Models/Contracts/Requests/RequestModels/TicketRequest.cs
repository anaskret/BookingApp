
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.RequestModels
{
    public class TicketRequest
    {
        public string Email { get; set; }
        public string BookingDate { get; set; }
        public string StatusId { get; set; }
    }
}
