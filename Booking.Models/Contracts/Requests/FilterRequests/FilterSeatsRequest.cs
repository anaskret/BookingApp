using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Booking.Models.Contracts.Requests.FilterRequests
{
    public class FilterSeatsRequest
    {
#nullable enable
        [Display(Name = "Minimum Seat Id")]
        public int? MinSeatId { get; set; }
        [Display(Name = "Maximum Seat Id")]
        public int? MaxSeatId { get; set; }
        [Display(Name = "Minimum Type Id")]
        public int? MinTypeId { get; set; }
        [Display(Name = "Maximum Type Id")]
        public int? MaxTypeId { get; set; }
        [Display(Name = "Minimum Seat Number")]
        public int? MinSeatNumber { get; set; }
        [Display(Name = "Maximum Seat Number")]
        public int? MaxSeatNumber { get; set; }
        [Display(Name = "Minimum Row Number")]
        public int? MinRowNumber { get; set; }
        [Display(Name = "Maximum Row Number")]
        public int? MaxRowNumber { get; set; }
        [Display(Name = "Minimum Sector Number")]
        public int? MinSectorNumber { get; set; }
        [Display(Name = "Maximum Sector Number")]
        public int? MaxSectorNumber { get; set; }
        [Display(Name = "Minimum Place Id")]
#nullable disable
        [Required]
        public int MinPlaceId { get; set; }
        [Required]
        [Display(Name = "Maximum Place Id")]
        public int MaxPlaceId { get; set; }
    }
}
