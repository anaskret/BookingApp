using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.GetRequests
{
    public class GetSeatTypesCountRequest
    {
        public string SeatType { get; set; }
        public int NumberOfSeatsByType { get; set; }
    }
}
