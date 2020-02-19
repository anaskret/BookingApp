using System;
using System.Collections.Generic;

namespace BookingApp.Models
{
    public partial class SeatPrice
    {
        public SeatPrice()
        {
            Seats = new HashSet<Seat>();
        }

        public string SeatType { get; set; }
        public decimal Price { get; set; }
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
