using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Models
{
    [Table("Places")]
    public class Place
    {
        public Place()
        {
            Event = new HashSet<Event>();
            Seats = new HashSet<Seat>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public int MaximumCapacity { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
