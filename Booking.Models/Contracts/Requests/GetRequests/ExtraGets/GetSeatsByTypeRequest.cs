using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.GetRequests
{
    public class GetSeatsByTypeRequest
    {
        public string SeatType { get; set; }
        public int NumberOfSeatsByType { get; set; }
    }
}
