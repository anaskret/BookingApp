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
        [Display(Name = "Event Id")]
        public int EventId { get; set; }
        [MinLength(3)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [MinLength(15)]
        public string Description { get; set; }

        [Display(Name = "Place Id")]
        public int PlaceId { get; set; }

        [Display(Name = "Type Id")]
        public int TypeId { get; set; }

        public int NumberOfSeats()
        {
            return Place.MaximumCapacity;
        }

        public int AvailableSeats()
        {
            return SeatStatuses.Select(x => x.Available == true).Count();
        }

        public virtual EventType Type { get; set; }
        public virtual Place Place { get; set; }
        public virtual ICollection<SectorPrice> SeatPrices { get; set; }
#nullable enable
        public virtual ICollection<SeatStatus>? SeatStatuses { get; set; }
#nullable disable
    }
}
