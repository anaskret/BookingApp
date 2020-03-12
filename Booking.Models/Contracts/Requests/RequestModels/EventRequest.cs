using System;
using System.ComponentModel.DataAnnotations;

namespace Booking.App.Contracts.Requests
{
    public class EventRequest
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        [Display(Name = "Place Id")]
        public int PlaceId { get; set; }
        [Display(Name = "Type Id")]
        public int TypeId { get; set; }
    }
}
