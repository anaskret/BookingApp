using Booking.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Models
{
    [Table("SectorPrices")]
    public class SectorPrice
    {
       /* public SectorPrice()
        {
            Seats = new HashSet<Seat>();
        }*/

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PriceId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public int EventId { get; set; }
        public int SectorNumber { get; set; }

        public virtual Event Event { get; set; }
#nullable enable
        public virtual ICollection<SeatStatus>? SeatStatuses { get; set; }
#nullable disable
    }
}
