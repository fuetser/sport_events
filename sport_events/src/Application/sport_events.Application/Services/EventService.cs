using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;

namespace SportEvents.Application.Services;
public class EventService(IEventRepository eventRepository) : IEventService
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public bool CreateEvent(EventCreateRequest request)
    {
        return _eventRepository.CreateEvent(request);
    }

    public bool DeleteEvent(int eventId)
    {
        return _eventRepository.DeleteEvent(eventId);
    }

    public EventResponse? GetEventById(int eventId)
    {
        return _eventRepository.GetEventById(eventId);
    }

    public IList<EventResponse> GetEvents()
    {
        return _eventRepository.GetEvents();
    }

    public IList<EventResponse> GetEventsByOrganizerId(int organizerId)
    {
        return _eventRepository.GetEventsByOrganizerId(organizerId);
    }

    public IList<EventResponse> GetEventsBySportId(int sportId)
    {
        return _eventRepository.GetEventsBySportId(sportId);
    }

    public IList<EventResponse> GetEventsBySportInTimeRange(int sportId, DateTime startTime, DateTime endTime)
    {
        return _eventRepository.GetEventsBySportInTimeRange(sportId, startTime, endTime);
    }

    public IList<EventResponse> GetEventsInTimeRange(DateTime startTime, DateTime endTime)
    {
        return _eventRepository.GetEventsInTimeRange(startTime, endTime);
    }

    public bool UpdateEvent(EventUpdateRequest request)
    {
        return _eventRepository.UpdateEvent(request);
    }
}
