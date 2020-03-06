using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.FilterRequests
{
    public class FilterSeatsRequest
    {
#nullable enable
        public int? MinSeatId { get; set; }
        public int? MaxSeatId { get; set; }
        public int? MinTypeId { get; set; }
        public int? MaxTypeId { get; set; }
        public int? MinSeatNumber { get; set; }
        public int? MaxSeatNumber { get; set; }
        public int? MinRowNumber { get; set; }
        public int? MaxRowNumber { get; set; }
        public string? SectorNumber { get; set; }
        public int? MinPlaceId { get; set; }
        public int? MaxPlaceId { get; set; }
#nullable disable
    }
}
