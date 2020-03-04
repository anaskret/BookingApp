using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Contracts.Requests.UpdateRequests;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Interfaces
{
    public interface IPlaceService
    {
        Task<IEnumerable<GetPlaceRequest>> GetAllPlaces();
        Task<GetPlaceRequest> GetPlaceById(int placeId);
        Task<Place> CreatePlace(CreatePlaceRequest createPlaceRequest);
        Task<bool> UpdatePlace(int placeId, UpdatePlaceRequest updatePlaceRequest);
        Task<bool> DeletePlace(int placeId);
        IEnumerable<GetPlaceRequest> FilterPlaces(string name, Dictionary<string, int[]> inDictionary);
    }
}
