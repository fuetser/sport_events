using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Contracts;
public interface IEventService
{
    EventModel GetEventById(Guid eventId);

    EventModel CreateEvent(EventModel model);

    EventModel UpdateEvent(Guid eventId, EventModel model);

    void DeleteEvent(Guid eventId);
}