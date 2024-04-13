using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Services;
public class EventService(IEventRepository eventRepository) : IEventService
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public Task<EventModel> CreateEvent(EventModel model)
    {
        return _eventRepository.CreateEvent(model);
    }

    public void DeleteEvent(Guid eventId)
    {
        _eventRepository.DeleteEvent(eventId);
    }

    public Task<EventModel> GetEventById(Guid eventId)
    {
        return _eventRepository.GetEventById(eventId);
    }

    public Task<IList<EventModel>> GetEvents()
    {
        return _eventRepository.GetEvents();
    }

    public Task<IList<EventModel>> GetEventsByOrganizerId(Guid organizerId)
    {
        return _eventRepository.GetEventsByOrganizerId(organizerId);
    }

    public Task<IList<EventModel>> GetEventsBySportId(Guid sportId)
    {
        return _eventRepository.GetEventsBySportId(sportId);
    }

    public Task<IList<EventModel>> GetEventsBySportInTimeRange(Guid sportId, DateTime startTime, DateTime endTime)
    {
        return _eventRepository.GetEventsBySportInTimeRange(sportId, startTime, endTime);
    }

    public Task<IList<EventModel>> GetEventsInTimeRange(DateTime startTime, DateTime endTime)
    {
        return _eventRepository.GetEventsInTimeRange(startTime, endTime);
    }

    public Task<EventModel> UpdateEvent(Guid eventId, EventModel model)
    {
        return _eventRepository.UpdateEvent(eventId, model);
    }
}
