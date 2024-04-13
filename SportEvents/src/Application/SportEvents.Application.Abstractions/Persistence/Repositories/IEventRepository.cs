using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface IEventRepository
{
    Task<IList<EventModel>> GetEvents();

    Task<IList<EventModel>> GetEventsBySportId(Guid sportId);

    Task<IList<EventModel>> GetEventsInTimeRange(DateTime startTime, DateTime endTime);

    Task<IList<EventModel>> GetEventsBySportInTimeRange(Guid sportId, DateTime startTime, DateTime endTime);

    Task<IList<EventModel>> GetEventsByOrganizerId(Guid organizerId);

    Task<EventModel> GetEventById(Guid eventId);

    Task<EventModel> CreateEvent(EventModel model);

    Task<EventModel> UpdateEvent(Guid eventId, EventModel model);

    void DeleteEvent(Guid eventId);
}
