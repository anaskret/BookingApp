﻿using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Interfaces
{
    public interface ITicketService
    {
        Task<GetTicketRequest> GetTicketById(Guid ticketId);
        Task<Ticket> CreateTicket(CreateTicketRequest createTicket);
    }
}