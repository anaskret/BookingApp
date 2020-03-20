using Booking.Models.Models;
using System;
using System.Threading.Tasks;

namespace Booking.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Task<Ticket> GetTicketById(Guid ticketId);
        Task<bool> CreateTicket(Ticket ticket);
    }
}
