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
    }
}
