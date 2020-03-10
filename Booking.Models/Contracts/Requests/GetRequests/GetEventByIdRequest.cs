using Booking.App.Contracts.Requests;
using Booking.Models.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.GetRequests
{
    public class GetEventByIdRequest: EventRequest
    {
        public int EventId { get; set; }
        public List<GetSeatTypesCountResponse> SeatTypesCount { get; set; }
#nullable enable
        public int? NumberOfSeats { get; set; }
        public int? AvailableSeats { get; set; }
    }
}
