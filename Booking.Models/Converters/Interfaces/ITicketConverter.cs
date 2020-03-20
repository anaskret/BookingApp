using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Models.Converters.Interfaces
{
    public interface ITicketConverter
    {
        GetTicketRequest TicketToGetTicketRequest(Ticket ticket);
        Ticket CreateTicketRequestToTicket(CreateTicketRequest ticket);
    }
}
