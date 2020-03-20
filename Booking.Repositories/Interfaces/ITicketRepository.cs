using Booking.Models.Models;
using System;
using System.Threading.Tasks;

namespace Booking.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> GetBookingById(Guid BookingId);
        Task<bool> CreateBooking(Booking Booking);
    }
}
