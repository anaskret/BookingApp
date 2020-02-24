using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Converters.Interfaces
{
    public interface IPlaceConverter
    {
        Place CreatePlaceRequestToPlace(CreatePlaceRequest createPlaceRequest);
        GetPlaceRequest PlaceToGetPlaceRequest(Place place);
    }
}
