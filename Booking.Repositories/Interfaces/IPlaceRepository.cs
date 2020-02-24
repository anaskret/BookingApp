using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Repositories.Interfaces
{
    public interface IPlaceRepository
    {
        List<Place> GetAllPlaces();
        Place GetPlaceById(int placeId);
        bool CreatePlace(Place place);
        bool UpdatePlace(Place place);
        bool DeletePlace(int placeId);
    }
}
