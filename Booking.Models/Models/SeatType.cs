using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Booking.Models.Models
{
    [Table("SeatTypes")]
    public class SeatType
    {
        public SeatType()
        {
            Seats = new HashSet<Seat>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Type Id")]
        public int TypeId { get; set; }
        [MinLength(2)]
        public string Type { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
    }
}
