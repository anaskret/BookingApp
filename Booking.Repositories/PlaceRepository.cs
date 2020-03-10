using Booking.Models.Contracts.Requests.FilterRequests;
using Booking.Models.Contracts.Requests.GetRequests;
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
    public class PlaceRepository : IPlaceRepository
    {
        private readonly BookingAppContext _dataContext;
        public PlaceRepository(BookingAppContext context)
        {
            _dataContext = context;
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

        public async Task<List<Place>> GetAllOrFilterPlace(FilterPlacesRequest filterPlaces)
        {
            var duplicatePlaces = new List<Place>();
            int queryCount = 0;

            if (FilterTools.AreIntsCorrect(filterPlaces.MinPlaceId, filterPlaces.MaxPlaceId))
            {
                var filterCapacity = _dataContext.Places.Where(c => c.MaximumCapacity >= filterPlaces.MinPlaceId
                 && c.MaximumCapacity <= filterPlaces.MaxPlaceId);
                foreach (var capacity in filterCapacity)
                    duplicatePlaces.Add(capacity);
                queryCount++;
            }

            if (filterPlaces.Name != null)
            {
                var filterNames = _dataContext.Places.Where(c => c.Name == filterPlaces.Name);
                foreach (var name in filterNames)
                    duplicatePlaces.Add(name);
                queryCount++;
            }

            if (FilterTools.AreIntsCorrect(filterPlaces.MinMaxCapacity, filterPlaces.MaxCapacity))
            { 
                var filterIds = _dataContext.Places.Where(c => c.PlaceId >= filterPlaces.MinMaxCapacity
                && c.PlaceId <= filterPlaces.MaxCapacity);
                foreach (var id in filterIds)
                    duplicatePlaces.Add(id);
                queryCount++;
            }

            var group = duplicatePlaces.GroupBy(i => i);
            var filtered = new List<Place>();

            if(queryCount == 0)
                return await _dataContext.Places.ToListAsync();

            foreach (var item in group)
            {
                if (item.Count() == queryCount)
                    filtered.Add(item.Key);
            }

            return filtered;
        }
    }
}
