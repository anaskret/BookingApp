using Booking.Models.Contracts.Requests.FilterRequests;
using Booking.Repositories.Interfaces;
using Booking.Repositories.Tools;
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

        public List<Seat> FilterSeats(FilterSeatsRequest filterSeats)
        {
            var duplicateSeats = new List<Seat>();
            int queryCount = 0;

            if(FilterTools.AreIntsCorrect(filterSeats.MinSeatId, filterSeats.MaxSeatId))
            {
                var filterIds = _dataContext.Seats.Where(x => x.SeatId >= filterSeats.MinSeatId
                && x.SeatId <= filterSeats.MaxSeatId);

                foreach (var id in filterIds)
                    duplicateSeats.Add(id);
                queryCount++;
            }

            if(FilterTools.AreIntsCorrect(filterSeats.MinTypeId, filterSeats.MaxSeatId))
            {
                var filterTypes = _dataContext.Seats.Where(x => x.SeatType >= filterSeats.MinTypeId
                && x.SeatType <= filterSeats.MaxSeatId);

                foreach (var type in filterTypes)
                    duplicateSeats.Add(type);
                queryCount++;
            }

            if (FilterTools.AreIntsCorrect(filterSeats.MinSeatNumber, filterSeats.MaxSeatNumber))
            {
                var filterSeatNums = _dataContext.Seats.Where(x => x.SeatNumber >= filterSeats.MinSeatNumber
                && x.SeatNumber <= filterSeats.MaxSeatNumber);

                foreach (var seatNum in filterSeatNums)
                    duplicateSeats.Add(seatNum);
                queryCount++;
            }

            if(FilterTools.AreIntsCorrect(filterSeats.MinRowNumber, filterSeats.MaxRowNumber))
            {
                var filterRows = _dataContext.Seats.Where(x => x.RowNumber >= filterSeats.MinRowNumber
                && x.RowNumber <= filterSeats.MaxRowNumber);

                foreach (var row in filterRows)
                    duplicateSeats.Add(row);
                queryCount++;
            }

            if(filterSeats.SectorNumber != null)
            {
                var filterSectors = _dataContext.Seats.Where(x => x.SectorNumber == filterSeats.SectorNumber);

                foreach (var sector in filterSectors)
                    duplicateSeats.Add(sector);
                queryCount++;
            }
            
            if (FilterTools.AreIntsCorrect(filterSeats.MinPlaceId, filterSeats.MaxPlaceId))
            {
                var filterPlaces = _dataContext.Seats.Where(x => x.PlaceId >= filterSeats.MinPlaceId
                && x.PlaceId <= filterSeats.MaxPlaceId);

                foreach (var place in filterPlaces)
                    duplicateSeats.Add(place);
                queryCount++;
            }

            var group = duplicateSeats.GroupBy(i => i);
            var finalSeats = new List<Seat>();

            foreach (var item in group)
                if (item.Count() == queryCount)
                    finalSeats.Add(item.Key);

            return finalSeats;
        }
    }
}
