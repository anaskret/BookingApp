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
        [Display(Name = "Seat Id")]
        public int SeatId { get; set; }

        [Display(Name = "Seat Number")]
        public int SeatNumber { get; set; }

        [Display(Name = "Row Number")]
        public int RowNumber { get; set; }

        [Display(Name = "Sector Number")]
        public int SectorNumber { get; set; }

        [Display(Name = "Type Id")]
        public int TypeId { get; set; }

        [Display(Name = "Place Id")]
        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }
        public virtual SeatType SeatType { get; set; }
        public virtual ICollection<SeatStatus> SeatStatuses { get; set; }
    }
}
