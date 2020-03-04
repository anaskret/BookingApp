using Booking.Models.Contracts.Requests.GetRequests;
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

        public List<Place> FilterPlace(string placeName, Dictionary<string, int[]> intDictionary)
        {
            var places = new List<Place>();

            var filterNames = _dataContext.Places.Where(c => c.Name == placeName);


            foreach (var item in intDictionary)
            {
                switch (item.Key)
                {
                    case "PlaceId":
                        var filterIds = _dataContext.Places.Where(c => c.PlaceId >= item.Value[0]
                        && c.PlaceId <= item.Value[1]);
                        foreach (var id in filterIds)
                            if (!places.Contains(id))
                                places.Add(id);
                        break;
                    case "MaximumCapacity":
                        var filterCapacity = _dataContext.Places.Where(c => c.MaximumCapacity >= item.Value[0]
                        && c.MaximumCapacity <= item.Value[1]);
                        foreach (var capacity in filterCapacity)
                            if (!places.Contains(capacity))
                                places.Add(capacity);
                        break;
                }
            }

            foreach (var name in filterNames)
                if (!places.Contains(name))
                    places.Add(name);

            return places;
        }
    }
}
