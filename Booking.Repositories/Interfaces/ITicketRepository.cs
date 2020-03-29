using Booking.Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetTickets();
        Task<Ticket> GetTicketById(Guid ticketId);
        Task<bool> CreateTicket(Ticket ticket);
    }
}
