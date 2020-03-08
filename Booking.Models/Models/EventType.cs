using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Models
{
    [Table("EventTypes")]
    public class EventType
    {
        public EventType()
        {
            Event = new HashSet<Event>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }
        public string Type { get; set; }
#nullable enable
        public virtual ICollection<Event>? Event { get; set; }
#nullable disable
    }
}
