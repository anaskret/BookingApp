﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Models
{
    public partial class Event
    {
        public Event()
        {
            SeatPrices = new HashSet<SeatPrice>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int PlaceId { get; set; }
        public int TypeId { get; set; }

        public virtual EventType TypeNavigation { get; set; }
        public virtual Place Place { get; set; }
        public virtual ICollection<SeatPrice> SeatPrices { get; set; }
    }
}
