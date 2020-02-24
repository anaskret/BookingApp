using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Converters.Interfaces;
using Booking.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booking.Services.Interfaces
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IPlaceConverter _placeConverter;

        public PlaceService(IPlaceRepository placeRepository, IPlaceConverter placeConverter)
        {
            _placeRepository = placeRepository;
            _placeConverter = placeConverter;
        }

        public IEnumerable<GetPlaceRequest> GetAllPlaces()
        {
            return _placeRepository.GetAllPlaces().Select(c => _placeConverter.PlaceToGetPlaceRequest(c));
        }

        public GetPlaceRequest GetPlaceById(int placeId)
        {
            var place = _placeConverter.PlaceToGetPlaceRequest(_placeRepository.GetPlaceById(placeId));

            return place;
        }
    }
}
