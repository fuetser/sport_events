using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.Entities;
using SportEvents.Application.Models.Models;
using SportEvents.Infrastructure.Persistence.Contexts;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Infrastructure.Persistence.Repositories;
public class EventRepository(ApplicationDbContext context) : IEventRepository
{
    private readonly ApplicationDbContext _context = context;

    public EventModel GetEventById(Guid eventId)
    {
        EEvent eevent = _context.Events.Find(eventId) ?? throw new NotFoundException($"Event with id {eventId} not found");
        return EventMapper.EntityToModel(eevent);
    }

    public EventModel CreateEvent(EventModel model)
    {
        var eevent = EventMapper.ModelToEntity(model);
        _context.Add(eevent);
        _context.SaveChanges();

        return model;
    }

    public EventModel UpdateEvent(Guid eventId, EventModel model)
    {
        var eevent = _context.Events.Find(eventId) ?? throw new NotFoundException($"Event with id {eventId} not found");

        eevent.Title = model.Title;
        eevent.Description = model.Description;
        eevent.StartTime = model.StartTime;
        eevent.EndTime = model.EndTime;

        _context.SaveChanges();
        return EventMapper.EntityToModel(eevent);
    }

    public void DeleteEvent(Guid eventId)
    {
        EEvent eevent = _context.Events.Find(eventId) ?? throw new NotFoundException($"Event with id {eventId} not found");
        _context.Events.Remove(eevent);
        _context.SaveChanges();
    }
}
