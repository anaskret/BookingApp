﻿using Booking.Models.Contracts.Requests.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.GetRequests
{
    public class GetPlaceRequest:PlaceRequest
    {
        public int PlaceId { get; set; }
    }
}