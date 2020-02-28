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
    public class PlaceRepository : IPlaceRepository
    {
        private readonly BookingAppContext _dataContext;
        public PlaceRepository(BookingAppContext context)
        {
            _dataContext = context;
        }


        public async Task<List<Place>> GetAllPlaces()
        {
            return await _dataContext.Places.ToListAsync();
        }

        public async Task<Place> GetPlaceById(int placeId)
        {
            return await _dataContext.Places.SingleOrDefaultAsync(x => x.PlaceId == placeId);
        }
        public async Task<bool> CreatePlace(Place place)
        {
            await _dataContext.Places.AddAsync(place);

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdatePlace(Place place)
        {
            _dataContext.Places.Update(place);

            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeletePlace(int placeId)
        {
            var place = await GetPlaceById(placeId);

            if (place == null)
                return false;

            _dataContext.Places.Remove(place);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
