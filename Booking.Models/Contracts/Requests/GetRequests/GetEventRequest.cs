using Booking.App.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.GetRequests
{
    public class GetEventRequest:EventRequest
    {
        public int EventId { get; set; }
    }
}
