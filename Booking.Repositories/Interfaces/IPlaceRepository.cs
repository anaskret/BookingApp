using Booking.Models.Contracts.Requests.FilterRequests;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repositories.Interfaces
{
    public interface IPlaceRepository
    {
        Task<List<Place>> GetAllPlaces();
        Task<Place> GetPlaceById(int placeId);
        Task<bool> CreatePlace(Place place);
        Task<bool> UpdatePlace(Place place);
        Task<bool> DeletePlace(int placeId);
        List<Place> FilterPlace(FilterPlacesRequest filterPlaces);
    }
}
