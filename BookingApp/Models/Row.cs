using System;
using System.Collections.Generic;

namespace BookingApp.Models
{
    public partial class Row
    {
        public Row()
        {
            Seats = new HashSet<Seat>();
        }

        public int PlaceId { get; set; }
        public int RowNumber { get; set; }
        public int SeatCount { get; set; }
        public string SectorNumber { get; set; }

        public virtual Sector Sectors { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
