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

    public Task<EventModel> UpdateEvent(Guid eventId, EventModel model)
    {
        return _eventRepository.UpdateEvent(eventId, model);
    }
}
