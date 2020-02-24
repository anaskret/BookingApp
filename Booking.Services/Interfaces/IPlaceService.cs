using Booking.Models.Contracts.Requests.GetRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Services.Interfaces
{
    public interface IPlaceService
    {
        IEnumerable<GetPlaceRequest> GetAllPlaces();
        GetPlaceRequest GetPlaceById(int placeId);
    }
}
