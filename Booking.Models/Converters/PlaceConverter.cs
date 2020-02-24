using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Contracts.Requests.UpdateRequests;
using Booking.Models.Converters.Interfaces;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Converters
{
    public class PlaceConverter : IPlaceConverter
    {
        public Place CreatePlaceRequestToPlace(CreatePlaceRequest createPlaceRequest)
        {
            return new Place
            {
                Name = createPlaceRequest.Name,
                MaximumCapacity = createPlaceRequest.MaximumCapacity
            };
        }

        public GetPlaceRequest PlaceToGetPlaceRequest(Place place)
        {
            if (place == null)
                return null;

            return new GetPlaceRequest
            {
                PlaceId = place.PlaceId,
                Name = place.Name,
                MaximumCapacity = place.MaximumCapacity
            };
        }

        public Place UpdatePlaceRequestToPlace(int placeId, UpdatePlaceRequest updatePlaceRequest)
        {
            return new Place
            {
                PlaceId = placeId,
                Name = updatePlaceRequest.Name,
                MaximumCapacity = updatePlaceRequest.MaximumCapacity
            };
        }
    }
}
