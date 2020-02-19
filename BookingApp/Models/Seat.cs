using System;
using System.Collections.Generic;

namespace BookingApp.Models
{
    public partial class Seat
    {
        public int SeatNumber { get; set; }
        public DateTime EventDate { get; set; }
        public int RowNumber { get; set; }
        public string SectorNumber { get; set; }
        public int PlaceId { get; set; }
        public int RefSeatStatusId { get; set; }
        public string SeatType { get; set; }

        public virtual RefSeatStatus RefSeatStatus { get; set; }
        public virtual Row Rows { get; set; }
        public virtual SeatPrice SeatPricesSeatTypeNavigation { get; set; }
    }
}
