using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface IEventRepository
{
    IList<EventResponse> GetEvents();

    IList<EventResponse> GetEventsBySportId(int sportId);

    IList<EventResponse> GetEventsInTimeRange(DateTime startTime, DateTime endTime);

    IList<EventResponse> GetEventsBySportInTimeRange(int sportId, DateTime startTime, DateTime endTime);

    IList<EventResponse> GetEventsByOrganizerId(int organizerId);

    EventResponse? GetEventById(int eventId);

    bool CreateEvent(EventCreateRequest request);

    bool UpdateEvent(EventUpdateRequest request);

    bool DeleteEvent(int eventId);
}
