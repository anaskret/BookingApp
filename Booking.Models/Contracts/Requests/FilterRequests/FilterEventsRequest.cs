using Booking.App.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Booking.Models.Contracts.Requests.FilterRequests
{
    public class FilterEventsRequest
    {
#nullable enable
        [Display(Name = "Minimum Event Id")]
        public int? MinEventId { get; set; }
        [Display(Name = "Maximum Event Id")]
        public int? MaxEventId { get; set; }
//#nullable disable
        public string? Name { get; set; }
        public string? Description { get; set; }
//#nullable enable
        [Display(Name = "Minimum Date")]
        public DateTime? MinDate { get; set; }
        [Display(Name = "Maximum Date")]
        public DateTime? MaxDate { get; set; }
        [Display(Name = "Minimum Place Id")]
        public int? MinPlaceId { get; set; }
        [Display(Name = "Maximum Place Id")]
        public int? MaxPlaceId { get; set; }
        [Display(Name = "Minimum Type Id")]
        public int? MinTypeId { get; set; }
        [Display(Name = "Maximum Place Id")]
        public int? MaxTypeId { get; set; }
#nullable disable
    }
}
