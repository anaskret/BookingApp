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
            var seats = new List<Seat>();

            if ((filterSeats.MinSeatId != null && filterSeats.MaxSeatId != null)
                || (filterSeats.MinSeatNumber != null && filterSeats.MaxSeatNumber != null)
                || (filterSeats.MinRowNumber != null && filterSeats.MaxRowNumber != null)
                || (filterSeats.MinTypeId != null && filterSeats.MaxTypeId != null)
                || (filterSeats.MinPlaceId != null && filterSeats.MaxPlaceId != null)
                || filterSeats.MinSectorNumber != null && filterSeats.MaxSectorNumber != null)
                seats = _seatRepository.FilterSeats(filterSeats);
            else
                seats = await _seatRepository.GetAllSeats();

            return seats.Select(c => _seatConverter.SeatToGetSeatRequest(c));
        }

        public async Task<GetSeatRequest> GetSeatById(int seatId)
        {
            return _seatConverter.SeatToGetSeatRequest(await _seatRepository.GetSeatById(seatId));
        }

        public async Task<Seat> CreateSeat(CreateSeatRequest createSeatRequest)
        {
            var create = _seatConverter.CreateSeatRequestToSeat(createSeatRequest);

            await _seatRepository.CreateSeat(create);

            return create;
        }

        public async Task<bool> UpdateSeat(UpdateSeatRequest updateSeatRequest, int seatId)
        {
            var update = _seatConverter.UpdateSeatRequestToSeat(updateSeatRequest, seatId);

            return await _seatRepository.UpdateSeat(update);
        }

        public async Task<bool> DeleteSeat(int seatId)
        {
            return await _seatRepository.DeleteSeat(seatId);
        }
    }
}
