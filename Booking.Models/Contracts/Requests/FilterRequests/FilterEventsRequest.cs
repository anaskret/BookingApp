using Booking.App.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.FilterRequests
{
    public class FilterEventsRequest
    {
#nullable enable
        public int? MinEventId { get; set; }
        public int? MaxEventId { get; set; }
//#nullable disable
        public string? Name { get; set; }
        public string? Description { get; set; }
//#nullable enable
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public int? MinPlaceId { get; set; }
        public int? MaxPlaceId { get; set; }
        public int? MinTypeId { get; set; }
        public int? MaxTypeId { get; set; }
#nullable disable
    }
}
