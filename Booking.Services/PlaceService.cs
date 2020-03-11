using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.FilterRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Contracts.Requests.UpdateRequests;
using Booking.Models.Converters.Interfaces;
using Booking.Repositories.Interfaces;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        

        public async Task<IEnumerable<GetPlaceRequest>> GetPlaces(FilterPlacesRequest filterPlaces = null)
        {
            var places = await _placeRepository.GetAllOrFilterPlace(filterPlaces);

            return places.Select(c => _placeConverter.PlaceToGetPlaceRequest(c));
        }

        public async Task<GetPlaceRequest> GetPlaceById(int placeId)
        {
            GetPlaceRequest place;
            try
            {
                place = _placeConverter.PlaceToGetPlaceRequest(await _placeRepository.GetPlaceById(placeId));
            }
            catch
            {
                throw;
            }

            return place;
        }
        
        public async Task<Place> CreatePlace(CreatePlaceRequest createPlaceRequest)
        {
            var create = _placeConverter.CreatePlaceRequestToPlace(createPlaceRequest);

            await _placeRepository.CreatePlace(create);

            return create;
        }

        public async Task<bool> UpdatePlace(int placeId, UpdatePlaceRequest updatePlaceRequest)
        {
            bool updated;
            try
            {
                updated = await _placeRepository.UpdatePlace(_placeConverter.UpdatePlaceRequestToPlace(placeId, updatePlaceRequest));
            }
            catch
            {
                throw;
            }

            return updated;
        }

        public async Task<bool> DeletePlace(int placeId)
        {
            return await _placeRepository.DeletePlace(placeId);
        }

        /*public async Task<IEnumerable<GetPlaceRequest>> FilterPlaces(FilterPlacesRequest filterPlaces)
        {
            var filteredPlaces = await _placeRepository.FilterPlace(filterPlaces);

            return filteredPlaces.Select(c => _placeConverter.PlaceToGetPlaceRequest(c));
        }*/
    }
}
