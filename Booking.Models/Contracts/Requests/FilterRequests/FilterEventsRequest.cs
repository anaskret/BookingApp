using Booking.App.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.FilterRequests
{
    public class FilterEventsRequest: EventRequest
    {
        public int MinEventId { get; set; }
        public int MaxEventId { get; set; }
        public int MinPlaceId { get; set; }
        public int MaxPlaceId { get; set; }
    }
}
