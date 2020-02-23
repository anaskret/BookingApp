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
#nullable enable      
        [Column(TypeName = "date")]
        public DateTime? EventDate { get; set; }
        public int? SeatType { get; set; }
#nullable disable
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
        public string SectorNumber { get; set; }
        public int PlaceId { get; set; }
        public int SeatStatusId { get; set; }

        public virtual SeatStatus SeatStatus { get; set; }
        public virtual Place Places{ get; set; }
        public virtual SeatPrice SeatPricesSeatTypeNavigation { get; set; }
    }
}
