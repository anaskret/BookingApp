using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BookingApp.Models
{
    [Table("Events")]
    public class Event
    {
        public Event()
        {
            SeatPrices = new HashSet<SectorPrice>();
            SeatStatuses = new HashSet<SeatStatus>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string Description { get; set; }
#nullable enable
        public int? NumberOfSeats { get; set; }
        public int? AvailableSeats { get; set; }
#nullable disable
        public int PlaceId { get; set; }
        public int TypeId { get; set; }

        public virtual EventType Type { get; set; }
        [ForeignKey("PlaceId")]
        public virtual Place Place { get; set; }
        public virtual ICollection<SectorPrice> SeatPrices { get; set; }
#nullable enable
        public virtual ICollection<SeatStatus>? SeatStatuses { get; set; }
#nullable disable
    }
}
