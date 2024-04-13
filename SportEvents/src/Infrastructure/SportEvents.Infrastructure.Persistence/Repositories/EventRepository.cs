using Microsoft.EntityFrameworkCore;
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
        try
        {
            var eevent = EventMapper.ModelToEntity(model);
            _context.Add(eevent);
            await _context.SaveChangesAsync();

            return model;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<Guid> DeleteEvent(Guid eventId)
    {
        try
        {
            EEvent eevent = await _context.Events.FindAsync(eventId) ?? throw new NotFoundException($"Event with id {eventId} not found");
            _context.Events.Remove(eevent);
            await _context.SaveChangesAsync();

            return eventId;
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<EventModel> GetEventById(Guid eventId)
    {
        try
        {
            EEvent eevent = await _context.Events.FindAsync(eventId) ?? throw new NotFoundException($"Event with id {eventId} not found");
            return EventMapper.EntityToModel(eevent);
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<IList<EventModel>> GetEvents()
    {
        try
        {
            var eventModels = await _context.Events.ToListAsync();
            return ConvertEventsToModels(eventModels);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<IList<EventModel>> GetEventsByOrganizerId(Guid organizerId)
    {
        try
        {
            var events = await _context.Events.Where(
                e => e.Organizers.Any(
                    o => o.Id == organizerId)).ToListAsync();
            return ConvertEventsToModels(events);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<IList<EventModel>> GetEventsBySportId(Guid sportId)
    {
        try
        {
            var events = await _context.Events.Where(
                e => e.Sports.Any(
                    s => s.Id == sportId)).ToListAsync();
            return ConvertEventsToModels(events);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<IList<EventModel>> GetEventsBySportInTimeRange(Guid sportId, DateTime startTime, DateTime endTime)
    {
        try
        {
            var events = await _context.Events.Where(
                e => e.Sports.Any(
                    s => s.Id == sportId) && e.StartTime >= startTime && e.EndTime <= endTime).ToListAsync();
            return ConvertEventsToModels(events);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<IList<EventModel>> GetEventsInTimeRange(DateTime startTime, DateTime endTime)
    {
        try
        {
            var eventModels = await _context.Events.Where(
                e => e.StartTime >= startTime && e.EndTime <= endTime).ToListAsync();
            return ConvertEventsToModels(eventModels);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<EventModel> UpdateEvent(Guid eventId, EventModel model)
    {
        try
        {
            var eevent = await _context.Events.FindAsync(eventId) ?? throw new NotFoundException($"Event with id {eventId} not found");

            eevent.Title = model.Title;
            eevent.Description = model.Description;
            eevent.StartTime = model.StartTime;
            eevent.EndTime = model.EndTime;

            await _context.SaveChangesAsync();
            return EventMapper.EntityToModel(eevent);
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    private List<EventModel> ConvertEventsToModels(IList<EEvent> events)
    {
        var eventModels = new List<EventModel>(events.Count);
        foreach (var eevent in events)
        {
            if (eevent is null)
                continue;

            eventModels.Add(EventMapper.EntityToModel(eevent));
        }

        return eventModels;
    }
}
