using Booking.Models.Contracts.Requests.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.CreateRequests
{
    public class CreateTicketRequest
    {
        public string Email { get; set; }
        public int StatusId { get; set; }
    }
}
