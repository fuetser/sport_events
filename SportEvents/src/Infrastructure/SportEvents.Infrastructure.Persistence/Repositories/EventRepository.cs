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

    public EventModel CreateEvent(EventModel model)
    {
        try
        {
            var eevent = EventMapper.ModelToEntity(model);
            _context.Add(eevent);
            _context.SaveChanges();

            return model;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public void DeleteEvent(Guid eventId)
    {
        try
        {
            EEvent eevent = _context.Events.Find(eventId) ?? throw new NotFoundException();
            _context.Events.Remove(eevent);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public EventModel GetEventById(Guid eventId)
    {
        try
        {
            EEvent eevent = _context.Events.Find(eventId) ?? throw new NotFoundException();
            return EventMapper.EntityToModel(eevent);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public IList<EventModel> GetEvents()
    {
        try
        {
            var eventModels = _context.Events.ToList();
            return ConvertEventsToModels(eventModels);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public IList<EventModel> GetEventsByOrganizerId(Guid organizerId)
    {
        try
        {
            var events = _context.Events.Where(
                e => e.Organizers.Any(
                    o => o.Id == organizerId)).ToList();
            return ConvertEventsToModels(events);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public IList<EventModel> GetEventsBySportId(Guid sportId)
    {
        try
        {
            var events = _context.Events.Where(
                e => e.Sports.Any(
                    s => s.Id == sportId)).ToList();
            return ConvertEventsToModels(events);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public IList<EventModel> GetEventsBySportInTimeRange(Guid sportId, DateTime startTime, DateTime endTime)
    {
        try
        {
            var events = _context.Events.Where(
                e => e.Sports.Any(
                    s => s.Id == sportId) && e.StartTime >= startTime && e.EndTime <= endTime).ToList();
            return ConvertEventsToModels(events);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public IList<EventModel> GetEventsInTimeRange(DateTime startTime, DateTime endTime)
    {
        try
        {
            var eventModels = _context.Events.Where(
                e => e.StartTime >= startTime && e.EndTime <= endTime).ToList();
            return ConvertEventsToModels(eventModels);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public EventModel UpdateEvent(Guid eventId, EventModel model)
    {
        try
        {
            var eevent = _context.Events.Find(eventId);
            if (eevent is null)
                throw new NotFoundException();

            eevent.Title = model.Title;
            eevent.Description = model.Description;
            eevent.StartTime = model.StartTime;
            eevent.EndTime = model.EndTime;

            _context.SaveChanges();
            return model;
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
