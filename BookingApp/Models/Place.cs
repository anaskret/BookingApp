using System;
using System.Collections.Generic;

namespace BookingApp.Models
{
    public partial class Place
    {
        public Place()
        {
            Event = new HashSet<Event>();
            Sectors = new HashSet<Sector>();
        }

        public int PlaceId { get; set; }
        public string Name { get; set; }
        public int MaximumCapacity { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<Sector> Sectors { get; set; }
    }
}
