using Booking.Models.Contracts.Requests.RequestModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Booking.Models.Contracts.Requests.FilterRequests
{
    public class FilterPlacesRequest
    {
#nullable enable
        [Display(Name = "Minimum Place Id")]
        public int? MinPlaceId { get; set; }
        [Display(Name = "Maximum Place Id")]
        public int? MaxPlaceId { get; set; }
        [Display(Name = "Minimum Capacity")]
        public int? MinMaxCapacity { get; set; }
        [Display(Name = "Maximum Capacity")]
        public int? MaxCapacity { get; set; }
        public string? Name { get; set; }
#nullable disable
    }
}
