﻿using Booking.Models.Contracts.Requests.FilterRequests;
using Booking.Models.Contracts.Responses;
using BookingApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Services.Interfaces
{
    public interface IEventRepository
    {
        Task<Event> GetEventById(int eventId);
        Task<List<Event>> GetAllOrFilterEvent(FilterEventsRequest filterEvents);
        Task<bool> CreateEvent(Event eventCreate);
        Task<bool> UpdateEvent(Event eventUpdate);
        Task<bool> DeleteEvent(int eventId);
        Task<List<GetSeatTypesCountResponse>> GetNumberOfSeatsByType(int placeId);
    }
}
