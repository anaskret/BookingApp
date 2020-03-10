using Booking.App.Contracts.Requests;
using Booking.Models.Contracts.Requests.FilterRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Contracts.Responses;
using BookingApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<GetEventRequest>> GetEvents(FilterEventsRequest filterEvents = null);
        Task<GetEventByIdRequest> GetEventById(int eventId);
        Task<Event> CreateEvent(CreateEventRequest createEventRequest);
        Task<bool> UpdateEvent(int eventId, UpdateEventRequest request);
        Task<bool> DeleteEvent(int eventId);
        Task<List<GetSeatTypesCountResponse>> GetNumberOfSeatsByType(int eventId);
    }
}
