using Booking.Models.Models;
using Booking.Repositories.Interfaces;
using BookingApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly BookingAppContext _dataContext;
        public TicketRepository(BookingAppContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<Ticket> GetTicketById(Guid ticketId)
        {
            var ticket = await _dataContext.Tickets.FirstOrDefaultAsync(t => t.TicketId == ticketId);

            if (ticket == null)
                throw new NullReferenceException("Selected ticket doesn't exist");

            _dataContext.Entry(ticket).Reference(t => t.SeatStatus).Load();
            _dataContext.Entry(ticket.SeatStatus).Reference(ss => ss.Seat).Load();
            _dataContext.Entry(ticket.SeatStatus).Reference(ss => ss.Event).Load();
            _dataContext.Entry(ticket.SeatStatus).Reference(ss => ss.SectorPrice).Load();

            return ticket;
        }

        public async Task<bool> CreateTicket(Ticket ticket)
        {
            var createTicket = await _dataContext.SeatStatuses.FirstOrDefaultAsync(ss => ss.StatusId == ticket.StatusId);

            if (createTicket == null)
                throw new NullReferenceException("Selected seat status doesn't exist");

            await _dataContext.AddAsync(ticket);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
    }
}
