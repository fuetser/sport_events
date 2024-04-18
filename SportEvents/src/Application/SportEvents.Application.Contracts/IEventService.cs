using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Contracts;
public interface IEventService
{
    Task<EventModel> GetEventById(Guid eventId);

    Task<EventModel> CreateEvent(EventModel model);

    Task<EventModel> UpdateEvent(Guid eventId, EventModel model);

    void DeleteEvent(Guid eventId);
}