using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Models;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;
using SportEvents.Infrastructure.Persistence.Contexts;

namespace SportEvents.Infrastructure.Persistence.Repositories;
public class EventRepository(ApplicationDbContext context) : IEventRepository
{
    private readonly ApplicationDbContext _context = context;

    public bool CreateEvent(EventCreateRequest request)
    {
        try
        {
            var eventModel = new EventModel(
                title: request.Title,
                description: request.Description,
                startTime: request.StartTime,
                endTime: request.EndTime);

            _context.Events.Add(eventModel);
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DeleteEvent(int eventId)
    {
        try
        {
            var eventModel = _context.Events.Find(eventId);
            if (eventModel is null)
                return false;

            _context.Events.Remove(eventModel);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public EventResponse? GetEventById(int eventId)
    {
        try
        {
            var eventModel = _context.Events.Find(eventId);
            return eventModel is null
                ? null
                : new EventResponse(
                Id: eventModel.Id,
                Title: eventModel.Title,
                Description: eventModel.Description,
                StartDate: eventModel.StartTime,
                EndDate: eventModel.EndTime);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public IList<EventResponse> GetEvents()
    {
        try
        {
            var eventModels = _context.Events.ToList();
            return ConvertEventModelsToResponses(eventModels);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public IList<EventResponse> GetEventsByOrganizerId(int organizerId)
    {
        try
        {
            var eventModels = _context.Events.Where(
                e => e.Organizers.Any(
                    o => o.Id == organizerId)).ToList();
            return ConvertEventModelsToResponses(eventModels);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public IList<EventResponse> GetEventsBySportId(int sportId)
    {
        try
        {
            var eventModels = _context.Events.Where(
                e => e.Sports.Any(
                    s => s.Id == sportId)).ToList();
            return ConvertEventModelsToResponses(eventModels);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public IList<EventResponse> GetEventsBySportInTimeRange(int sportId, DateTime startTime, DateTime endTime)
    {
        try
        {
            var eventModels = _context.Events.Where(
                e => e.Sports.Any(
                    s => s.Id == sportId) && e.StartTime >= startTime && e.EndTime <= endTime).ToList();
            return ConvertEventModelsToResponses(eventModels);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public IList<EventResponse> GetEventsInTimeRange(DateTime startTime, DateTime endTime)
    {
        try
        {
            var eventModels = _context.Events.Where(
                e => e.StartTime >= startTime && e.EndTime <= endTime).ToList();
            return ConvertEventModelsToResponses(eventModels);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public bool UpdateEvent(EventUpdateRequest request)
    {
        try
        {
            var eventModel = _context.Events.Find(request.Id);
            if (eventModel is null)
                return false;

            eventModel.Title = request.Title;
            eventModel.Description = request.Description;
            eventModel.StartTime = request.StartTime;
            eventModel.EndTime = request.EndTime;

            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private List<EventResponse> ConvertEventModelsToResponses(IList<EventModel> eventModels)
    {
        var eventResponses = new List<EventResponse>(eventModels.Count);
        foreach (var eventModel in eventModels)
        {
            if (eventModel is null)
                continue;

            eventResponses.Add(
                new EventResponse(
                    Id: eventModel.Id,
                    Title: eventModel.Title,
                    Description: eventModel.Description,
                    StartDate: eventModel.StartTime,
                    EndDate: eventModel.EndTime));
        }

        return eventResponses;
    }
}
