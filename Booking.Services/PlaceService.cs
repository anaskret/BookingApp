using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Contracts.Requests.UpdateRequests;
using Booking.Models.Converters.Interfaces;
using Booking.Repositories.Interfaces;
using BookingApp.Models;
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
        
        public Place CreatePlace(CreatePlaceRequest createPlaceRequest)
        {
            var create = _placeConverter.CreatePlaceRequestToPlace(createPlaceRequest);

            _placeRepository.CreatePlace(create);

            return create;
        }

        public bool UpdatePlace(int placeId, UpdatePlaceRequest updatePlaceRequest)
        {
            var updated = _placeRepository.UpdatePlace(_placeConverter.UpdatePlaceRequestToPlace(placeId, updatePlaceRequest));

            return updated;
        }

        public bool DeletePlace(int placeId)
        {
            var deleted = _placeRepository.DeletePlace(placeId);

            return deleted;
        }
    }
}
