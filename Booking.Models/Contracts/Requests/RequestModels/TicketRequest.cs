﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Contracts.Requests.RequestModels
{
    public class TicketRequest
    {
        public string Email { get; set; }
        public DateTime BookingDate { get; set; }
        public int StatusId { get; set; }
    }
}