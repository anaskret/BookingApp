using Booking.Models.Contracts.Requests.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.GetRequests
{
    public class GetSeatRequest: SeatRequest
    {
        public int SeatId { get; set; }
    }
}
