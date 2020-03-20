using Booking.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Models
{
    [Table("SeatStatuses")]
    public class SeatStatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Status Id")]
        public int StatusId { get; set; }

        public bool Available { get; set; } = true;

        [Display(Name = "Seat Id")]
        public int SeatId { get; set; }

        [Display(Name = "Event Id")]
        public int EventId { get; set; }

        [Display(Name = "Place Id")]
        public int PriceId { get; set; }

        public virtual Seat Seat { get; set; }
        public virtual Event Event { get; set; }
        public virtual SectorPrice SectorPrice { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
