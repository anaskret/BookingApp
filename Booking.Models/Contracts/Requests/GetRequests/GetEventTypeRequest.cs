using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.GetRequests
{
    public class GetEventTypeRequest
    {
        public int TypeId { get; set; }
        public string Type { get; set; }
    }
}
