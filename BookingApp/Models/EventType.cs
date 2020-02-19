using System;
using System.Collections.Generic;

namespace BookingApp.Models
{
    public partial class EventType
    {
        public EventType()
        {
            Event = new HashSet<Event>();
        }

        public string Type { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
