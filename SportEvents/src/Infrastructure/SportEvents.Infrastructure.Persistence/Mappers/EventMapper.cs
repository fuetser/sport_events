using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Entities;
using SportEvents.Application.Models.Models;

namespace SportEvents.Infrastructure.Persistence.Mappers;
public class EventMapper
{
    public static EEvent ModelToEntity(EventModel model)
    {
        return new EEvent
        {
            Id = model.Id,
            Title = model.Title,
            Description = model.Description,
            StartTime = model.StartTime,
            EndTime = model.EndTime,
            VenueId = model.VenueId,
            SportId = model.SportId,
            OrganizerId = model.OrganizerId,
        };
    }

    public static EventModel EntityToModel(EEvent eevent)
    {
        return new EventModel
        {
            Id = eevent.Id,
            Title = eevent.Title,
            Description = eevent.Description,
            StartTime = eevent.StartTime,
            EndTime = eevent.EndTime,
            VenueId = eevent.VenueId,
            SportId = eevent.SportId,
            OrganizerId = eevent.OrganizerId,
        };
    }

    public static EventModel EventCreateToModel(EventCreateRequest request)
    {
        return new EventModel
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            VenueId = request.VenueId,
            SportId = request.SportId,
            OrganizerId = request.OrganizerId,
        };
    }

    public static EventModel EventUpdateToModel(EventUpdateRequest request)
    {
        return new EventModel
        {
            Id = Guid.Empty,
            Title = request.Title,
            Description = request.Description,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            VenueId = request.VenueId,
            SportId = request.SportId,
            OrganizerId = request.OrganizerId,
        };
    }

    public static EventResponse ModelToReponse(EventModel model)
    {
        return new EventResponse(
            Id: model.Id,
            Title: model.Title,
            Description: model.Description,
            StartDate: model.StartTime,
            EndDate: model.EndTime,
            VenueId: model.VenueId,
            SportId: model.SportId,
            OrganizerId: model.OrganizerId);
    }
}
