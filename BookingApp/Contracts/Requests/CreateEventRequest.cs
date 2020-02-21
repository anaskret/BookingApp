using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.App.Contracts.Requests
{
    public class CreateEventRequest
    {
        public string Name { get; set; }
        public DateTime Date{ get; set; }
        public string Description{ get; set; }
        public int PlaceId { get; set; }
        public int TypeId { get; set; }
    }
}
