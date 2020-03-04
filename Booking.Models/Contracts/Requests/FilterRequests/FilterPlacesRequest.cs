using Booking.Models.Contracts.Requests.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.FilterRequests
{
    public class FilterPlacesRequest
    {
        public int MinPlaceId { get; set; }
        public int MaxPlaceId { get; set; }
        public int MinMaxCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public string Name { get; set; }
    }
}
