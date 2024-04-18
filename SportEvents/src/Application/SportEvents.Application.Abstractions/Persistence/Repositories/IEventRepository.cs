using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface IEventRepository
{
    Task<EventModel> GetEventById(Guid eventId);

    Task<EventModel> CreateEvent(EventModel model);

    Task<EventModel> UpdateEvent(Guid eventId, EventModel model);

    Task<Guid> DeleteEvent(Guid eventId);
}
