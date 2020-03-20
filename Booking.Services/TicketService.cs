using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Converters.Interfaces;
using Booking.Models.Models;
using Booking.Repositories.Interfaces;
using Booking.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketConverter _ticketConverter;

        public TicketService(ITicketRepository ticketRepository, ITicketConverter ticketConverter)
        {
            _ticketRepository = ticketRepository;
            _ticketConverter = ticketConverter;
        }

        public async Task<GetTicketRequest> GetTicketById(Guid ticketId)
        {
            GetTicketRequest ticket;
            try
            {
                ticket = _ticketConverter.TicketToGetTicketRequest(await _ticketRepository.GetTicketById(ticketId));
            }
            catch
            {
                throw;
            }

            return ticket;
        }
        
        public async Task<Ticket> CreateTicket(CreateTicketRequest createTicket)
        {
            Ticket ticket;
            try
            {
                ticket = _ticketConverter.CreateTicketRequestToTicket(createTicket);
            }
            catch
            {
                throw;
            }

            await _ticketRepository.CreateTicket(ticket);

            return ticket;
        }
    }
}
