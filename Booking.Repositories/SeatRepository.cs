using Booking.Repositories.Interfaces;
using BookingApp.Data;
using BookingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly BookingAppContext _dataContext;
        public SeatRepository(BookingAppContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Seat>> GetAllSeats()
        {
            return await _dataContext.Seats.ToListAsync();
        }

        public async Task<Seat> GetSeatById(int seatId)
        {
            return await _dataContext.Seats.SingleOrDefaultAsync(x => x.SeatId == seatId);
        }

        public async Task<bool> CreateSeat(Seat seat)
        {
            await _dataContext.AddAsync(seat);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateSeat(Seat seat)
        {
            _dataContext.Update(seat);

            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteSeat(int seatId)
        {
            var deleteSeat = await GetSeatById(seatId);

            if (deleteSeat == null)
                return false;

            _dataContext.Remove(deleteSeat);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
