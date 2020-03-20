using Booking.App.Contracts.Requests;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Booking.Models.Contracts.Requests.GetRequests
{
    public class GetEventByIdRequest : EventRequest
    {
        public int EventId { get; set; }
        public List<GetSeatsByTypeRequest> SeatTypesCount { get; set; }
        public List<GetSectorPricesRequest> SectorPrices { get; set; }
#nullable enable
        public int? NumberOfSeats { get; set; }
        public int? AvailableSeats { get; set; }
#nullable disable
    }
}
