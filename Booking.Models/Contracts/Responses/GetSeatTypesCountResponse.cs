using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Responses
{
    public class GetSeatTypesCountResponse
    {
        public string SeatType { get; set; }
        public int NumberOfSeatsByType { get; set; }
    }
}
