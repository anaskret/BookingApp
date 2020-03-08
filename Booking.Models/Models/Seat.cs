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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatId { get; set; }
        public int TypeId { get; set; }
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
        public int SectorNumber { get; set; }
        public int PlaceId { get; set; }

        [ForeignKey("PlaceId")]
        public virtual Place Place { get; set; }
        [ForeignKey("TypeId")]
        public virtual SeatType SeatType { get; set; }
#nullable enable
        public virtual SeatStatus? SeatStatuses { get; set; }
#nullable disable
    }
}
