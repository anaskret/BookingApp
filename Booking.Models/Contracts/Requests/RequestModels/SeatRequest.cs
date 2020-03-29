namespace Booking.Models.Contracts.Requests.RequestModels
{
    public class SeatRequest
    {
        public int TypeId { get; set; }
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
        public int SectorNumber { get; set; }
        public int PlaceId { get; set; }
    }
}
