﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Contracts
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Base = Root;

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
            public const string GetAll = Base + "/places";
            public const string Get= Base + "/places/{placeId}";
        }
    }
}
