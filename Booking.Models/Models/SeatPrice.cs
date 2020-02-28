using Booking.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Models
{
    [Table("SeatPrices")]
    public class SeatPrice
    {
        public SeatPrice()
        {
            Seats = new HashSet<Seat>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatPriceId { get; set; }
        public int SeatType { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public int EventId { get; set; }

        public virtual SeatType SeatTypes { get; set; }
        public virtual Event Event { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
