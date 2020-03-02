using Booking.Models.Contracts.Requests.GetRequests;
using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Services.Interfaces
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllEvents();
        Task<Event> GetEventById(int eventId);
        Task<bool> CreateEvent(Event eventCreate);
        Task<bool> UpdateEvent(Event eventUpdate);
        Task<bool> DeleteEvent(int eventId);
        List<Event> FilterEvent(Dictionary<string, string> stringDictionary, Dictionary<string, int> intDictionary);
    }
}
