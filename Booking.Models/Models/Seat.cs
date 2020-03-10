using Booking.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Models
{
    [Table("Seats")]
    public class Seat
    {
        public Seat()
        {
            SeatStatuses = new HashSet<SeatStatus>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatId { get; set; }
        public int TypeId { get; set; }
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
        public int SectorNumber { get; set; }
        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }
        public virtual SeatType SeatType { get; set; }
        public virtual ICollection<SeatStatus> SeatStatuses { get; set; }
    }
}
