using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface IEventRepository
{
    EventModel GetEventById(Guid eventId);

    EventModel CreateEvent(EventModel model);

    EventModel UpdateEvent(Guid eventId, EventModel model);

    void DeleteEvent(Guid eventId);
}
