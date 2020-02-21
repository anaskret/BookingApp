using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Models
{
    [Table("SeatStatuses")]
    public class SeatStatus
    {
        public SeatStatus()
        {
            Seats = new HashSet<Seat>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusId { get; set; }
        public string StatusDescription { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
    }
}
