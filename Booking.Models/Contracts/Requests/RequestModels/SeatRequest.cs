using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.RequestModels
{
    public class SeatRequest
    {
        public int? SeatType { get; set; }
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
        public string SectorNumber { get; set; }
        public int PlaceId { get; set; }
    }
}
