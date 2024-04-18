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

    public async Task<EventModel> CreateEvent(EventModel model)
    {
        var eevent = EventMapper.ModelToEntity(model);
        _context.Add(eevent);
        await _context.SaveChangesAsync();

        return model;
    }

    public async Task<Guid> DeleteEvent(Guid eventId)
    {
        EEvent eevent = await _context.Events.FindAsync(eventId) ?? throw new NotFoundException($"Event with id {eventId} not found");
        _context.Events.Remove(eevent);
        await _context.SaveChangesAsync();

        return eventId;
    }

    public async Task<EventModel> GetEventById(Guid eventId)
    {
        EEvent eevent = await _context.Events.FindAsync(eventId) ?? throw new NotFoundException($"Event with id {eventId} not found");
        return EventMapper.EntityToModel(eevent);
    }

    public async Task<EventModel> UpdateEvent(Guid eventId, EventModel model)
    {
        var eevent = await _context.Events.FindAsync(eventId) ?? throw new NotFoundException($"Event with id {eventId} not found");

        eevent.Title = model.Title;
        eevent.Description = model.Description;
        eevent.StartTime = model.StartTime;
        eevent.EndTime = model.EndTime;

        await _context.SaveChangesAsync();
        return EventMapper.EntityToModel(eevent);
    }
}
