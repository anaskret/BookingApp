using System;
using System.ComponentModel.DataAnnotations;

namespace Booking.App.Contracts.Requests
{
    public class EventRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int PlaceId { get; set; }
        [Required]
        public int TypeId { get; set; }
    }
}
