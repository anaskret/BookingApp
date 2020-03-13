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
            Events = new HashSet<Event>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "TypeId")]
        public int TypeId { get; set; }
        [MinLength(2)]
        public string Type { get; set; }
#nullable enable
        public virtual ICollection<Event>? Events { get; set; }
#nullable disable
    }
}
