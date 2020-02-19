using System;
using System.Collections.Generic;

namespace BookingApp.Models
{
    public partial class RefSeatStatus
    {
        public RefSeatStatus()
        {
            Seats = new HashSet<Seat>();
        }

        public int StatusId { get; set; }
        public string StatusDescription { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
    }
}
