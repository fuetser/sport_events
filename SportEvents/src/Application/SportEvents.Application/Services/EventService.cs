using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Services;
public class EventService(IEventRepository eventRepository) : IEventService
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public EventModel GetEventById(Guid eventId)
    {
        return _eventRepository.GetEventById(eventId);
    }

    public EventModel CreateEvent(EventModel model)
    {
        if (model.StartTime.CompareTo(model.EndTime) >= 0)
        {
            throw new ArgumentException("Start time must be less than end time");
        }

        return _eventRepository.CreateEvent(model);
    }

    public EventModel UpdateEvent(Guid eventId, EventModel model)
    {
        if (model.StartTime.CompareTo(model.EndTime) >= 0)
        {
            throw new ArgumentException("Start time must be less than end time");
        }

        return _eventRepository.UpdateEvent(eventId, model);
    }

    public void DeleteEvent(Guid eventId)
    {
        _eventRepository.DeleteEvent(eventId);
    }
}
