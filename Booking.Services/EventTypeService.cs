using Booking.Models.Contracts.Requests.GetRequests;
using Booking.Models.Converters.Interfaces;
using Booking.Repositories.Interfaces;
using Booking.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class EventTypeService : IEventTypeService
    {
        private readonly IEventTypeRepository _eventTypeRepository;
        private readonly IEventTypeConverter _eventTypeConverter;

        public EventTypeService(IEventTypeRepository eventTypeRepository, IEventTypeConverter eventTypeConverter)
        {
            _eventTypeRepository = eventTypeRepository;
            _eventTypeConverter = eventTypeConverter;
        }

        public async Task<ICollection<GetEventTypeRequest>> GetEventTypes()
        {
            var types = await _eventTypeRepository.GetEventTypes();
            return types.Select(t => _eventTypeConverter.EventTypeToGetEventTypeRequest(t)).ToList();
        }
    }
}
