using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Contracts.Requests.UpdateRequests;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Services.Interfaces
{
    public interface IPlaceService
    {
        IEnumerable<GetPlaceRequest> GetAllPlaces();
        GetPlaceRequest GetPlaceById(int placeId);
        Place CreatePlace(CreatePlaceRequest createPlaceRequest);
        bool UpdatePlace(int placeId, UpdatePlaceRequest updatePlaceRequest);
        bool DeletePlace(int placeId);
    }
}
