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
        Task<Place> GetPlaceById(int placeId);
        Task<List<Place>> GetAllOrFilterPlace(FilterPlacesRequest filterPlaces);
        Task<bool> CreatePlace(Place place);
        Task<bool> UpdatePlace(Place place);
        Task<bool> DeletePlace(int placeId);
    }
}
