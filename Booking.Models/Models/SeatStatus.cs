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
        public int StatusId { get; set; }
        [DefaultValue(true)]
        public bool? Available { get; set; }
#nullable enable
        public int? SeatId { get; set; }
        public int? EventId { get; set; }
        public int? PriceId { get; set; }

        public virtual Seat? Seat { get; set; }
        public virtual Event? Event { get; set; }
        public virtual SectorPrice? SectorPrice { get; set; }
#nullable disable
    }
}
