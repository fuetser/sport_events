using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Entities;
using SportEvents.Application.Models.Models;

namespace SportEvents.Infrastructure.Persistence.Mappers;
public class OrganizerMapper
{
    public static Organizer ModelToEntity(OrganizerModel model)
    {
        return new Organizer
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Email = model.Email,
            Phone = model.Phone,
        };
    }

    public static OrganizerModel EntityToModel(Organizer organizer)
    {
        return new OrganizerModel
        {
            Id = organizer.Id,
            Name = organizer.Name,
            Description = organizer.Description,
            Email = organizer.Email,
            Phone = organizer.Phone,
        };
    }

    public static OrganizerModel OrganizerCreateToModel(OrganizerCreateRequest request)
    {
        return new OrganizerModel
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Email = request.Email,
            Phone = request.Phone,
        };
    }

    public static OrganizerModel OrganizerUpdateToModel(OrganizerUpdateRequest request)
    {
        return new OrganizerModel
        {
            Id = Guid.Empty,
            Name = request.Name,
            Description = request.Description,
            Email = request.Email,
            Phone = request.Phone,
        };
    }

    public static OrganizerResponse ModelToReponse(OrganizerModel model)
    {
        return new OrganizerResponse(
            Id: model.Id,
            Name: model.Name,
            Description: model.Description,
            Email: model.Email,
            Phone: model.Phone);
    }
}
