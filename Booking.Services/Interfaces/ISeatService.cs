using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Contracts.Requests.UpdateRequests;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Interfaces
{
    public interface ISeatService
    {
        Task<IEnumerable<GetSeatRequest>> GetAllSeats();
        Task<GetSeatRequest> GetSeatById(int seatId);
        Task<Seat> CreateSeat(CreateSeatRequest createSeatRequest);
        Task<bool> UpdateSeat(UpdateSeatRequest updateSeatRequest, int seatId);
        Task<bool> DeleteSeat(int seatId);
    }
}
