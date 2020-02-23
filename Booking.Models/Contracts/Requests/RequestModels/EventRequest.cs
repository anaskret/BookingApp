using System;

namespace Booking.App.Contracts.Requests
{
    public class EventRequest
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int PlaceId { get; set; }
        public int TypeId { get; set; }
    }
}
