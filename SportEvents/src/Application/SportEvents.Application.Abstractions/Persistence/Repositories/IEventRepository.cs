using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface IEventRepository
{
    IList<EventModel> GetEvents();

    IList<EventModel> GetEventsBySportId(Guid sportId);

    IList<EventModel> GetEventsInTimeRange(DateTime startTime, DateTime endTime);

    IList<EventModel> GetEventsBySportInTimeRange(Guid sportId, DateTime startTime, DateTime endTime);

    IList<EventModel> GetEventsByOrganizerId(Guid organizerId);

    EventModel GetEventById(Guid eventId);

    EventModel CreateEvent(EventModel model);

    EventModel UpdateEvent(Guid eventId, EventModel model);

    void DeleteEvent(Guid eventId);
}
