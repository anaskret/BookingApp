using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.GetRequests
{
    public class GetSeatsByType
    {
        public string SeatType { get; set; }
        public int NumberOfSeatsByType { get; set; }
    }
}
