using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.FilterRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Contracts.Requests.UpdateRequests;
using Booking.Models.Converters.Interfaces;
using Booking.Repositories.Interfaces;
using Booking.Services.Interfaces;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepository;
        private readonly ISeatConverter _seatConverter;

        public SeatService(ISeatRepository seatRepository, ISeatConverter seatConverter)
        {
            _seatRepository = seatRepository;
            _seatConverter = seatConverter;
        }
        public async Task<IEnumerable<GetSeatRequest>> GetSeats(FilterSeatsRequest filterSeats)
        {
            var seats = await _seatRepository.GetAllOrFilterSeats(filterSeats);

            return seats.Select(c => _seatConverter.SeatToGetSeatRequest(c));
        }

        public async Task<GetSeatRequest> GetSeatById(int seatId)
        {
            Seat seat;
            try
            {
                seat = await _seatRepository.GetSeatById(seatId);
            }
            catch
            {
                throw;
            }

            return _seatConverter.SeatToGetSeatRequest(seat);
        }

        public async Task<Seat> CreateSeat(CreateSeatRequest createSeatRequest)
        {
            var create = _seatConverter.CreateSeatRequestToSeat(createSeatRequest);

            try
            {
                await _seatRepository.CreateSeat(create);
            }
            catch
            {
                throw;
            }

            return create;
        }

        public async Task<bool> UpdateSeat(UpdateSeatRequest updateSeatRequest, int seatId)
        {
            var update = _seatConverter.UpdateSeatRequestToSeat(updateSeatRequest, seatId);
            bool updated;
            try
            {
                updated = await _seatRepository.UpdateSeat(update);
            }
            catch
            {
                return false;
            }
            return updated;
        }

        public async Task<bool> DeleteSeat(int seatId)
        {
            return await _seatRepository.DeleteSeat(seatId);
        }
    }
}
