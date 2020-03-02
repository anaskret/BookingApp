using Booking.App.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.FilterRequests
{
    public class FilterEventsRequest: EventRequest
    {
        public int EventId { get; set; }
    }
}
