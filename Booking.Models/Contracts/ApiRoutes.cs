using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Contracts
{
    public class ApiRoutes
    {
        private const string Root = "api";
        private const string Base = Root;

        public static class Events
        {
            public const string Create = Base + "/events";
            public const string GetAll = Base + "/events";
            public const string Get = Base + "/events/{eventId}";
            public const string Update = Base + "/events/{eventId}";
            public const string Delete = Base + "/events/{eventId}";
        }

        public static class Places
        {
            public const string Create = Base + "/places";
            public const string GetAll = Base + "/places";
            public const string Get = Base + "/places/{placeId}";
            public const string Update = Base + "/places/{placeId}";
            public const string Delete= Base + "/places/{placeId}";
        }

        public static class Seats
        {
            public const string Create = Base + "/seats";
            public const string GetAll = Base + "/seats";
            public const string Get = Base + "/seats/{seatId}";
            public const string Update = Base + "/seats/{seatId}";
            public const string Delete = Base + "/seats/{seatId}";
        }
        
        public static class Tickets
        {
            public const string Get = Base + "/Bookings/{BookingId}";
            public const string Create = Base + "/Bookings/";
        }
    }
}
