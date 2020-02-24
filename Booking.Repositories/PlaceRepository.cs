using Booking.Repositories.Interfaces;
using BookingApp.Data;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booking.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly BookingAppContext _dataContext;
        public PlaceRepository(BookingAppContext context)
        {
            _dataContext = context;
        }


        public List<Place> GetAllPlaces()
        {
            return _dataContext.Places.ToList();
        }

        public Place GetPlaceById(int placeId)
        {
            return _dataContext.Places.SingleOrDefault(x => x.PlaceId == placeId);
        }
        public bool CreatePlace(Place place)
        {
            _dataContext.Places.Add(place);

            var created = _dataContext.SaveChanges();

            return created > 0;
        }

        public bool UpdatePlace(Place place)
        {
            _dataContext.Places.Update(place);

            var updated = _dataContext.SaveChanges();

            return updated > 0;
        }

        public bool DeletePlace(int placeId)
        {
            var place = GetPlaceById(placeId);

            if (place == null)
                return false;

            _dataContext.Places.Remove(place);

            var deleted = _dataContext.SaveChanges();

            return deleted > 0;
        }
    }
}
