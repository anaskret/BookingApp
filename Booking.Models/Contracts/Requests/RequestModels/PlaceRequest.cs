using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.RequestModels
{
    public class PlaceRequest
    {
        public string Name { get; set; }
        public int MaximumCapacity { get; set; }
    }
}
