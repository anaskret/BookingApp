using Booking.Models.Contracts.Requests.GetRequests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Services.Interfaces
{
    public interface IEventTypeService
    {
        Task<IEnumerable<GetEventTypeRequest>> GetEventTypes();
    }
}
