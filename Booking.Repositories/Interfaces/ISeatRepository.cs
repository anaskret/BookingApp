using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repositories.Interfaces
{
    public interface ISeatRepository
    {
        Task<List<Seat>> GetAllSeats();
        Task<Seat> GetSeatById(int seatId);
        Task<bool> CreateSeat(Seat seat);
        Task<bool> UpdateSeat(Seat seat);
        Task<bool> DeleteSeat(int seatId);
    }
}
