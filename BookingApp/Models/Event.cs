using System;
using System.Collections.Generic;

namespace BookingApp.Models
{
    public partial class Event
    {
        public Event()
        {
            SeatPrices = new HashSet<SeatPrice>();
        }

        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int? PlaceId { get; set; }
        public string Type { get; set; }

        public virtual EventType TypeNavigation { get; set; }
        public virtual Place Place { get; set; }
        public virtual ICollection<SeatPrice> SeatPrices { get; set; }
    }
}
