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
        /*public SeatStatus()
        {
            
        }*/

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusId { get; set; }
        [DefaultValue(true)]
        public bool? Available { get; set; }
        public int SeatId { get; set; }
        public int EventId { get; set; }
        public int PriceId { get; set; }

        [ForeignKey("SeatId")]
        public virtual Seat Seat { get; set; }
        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
        [ForeignKey("PriceId")]
        public virtual SectorPrice SectorPrice { get; set; }

    }
}
