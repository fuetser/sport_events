using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Entities;
using SportEvents.Application.Models.Models;

namespace SportEvents.Infrastructure.Persistence.Mappers;
public class VenueMapper
{
    public static Venue ModelToEntity(VenueModel model)
    {
        return new Venue
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Address = model.Address,
            Capacity = model.Capacity,
        };
    }

    public static VenueModel EntityToModel(Venue venue)
    {
        return new VenueModel
        {
            Id = venue.Id,
            Name = venue.Name,
            Description = venue.Description,
            Address = venue.Address,
            Capacity = venue.Capacity,
        };
    }

    public static VenueModel VenueCreateToModel(VenueCreateRequest request)
    {
        return new VenueModel
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Address = request.Address,
            Capacity = request.Capacity,
        };
    }

    public static VenueModel VenueUpdateToModel(VenueUpdateRequest request)
    {
        return new VenueModel
        {
            Id = Guid.Empty,
            Name = request.Name,
            Description = request.Description,
            Address = request.Address,
            Capacity = request.Capacity,
        };
    }

    public static VenueResponse ModelToReponse(VenueModel model)
    {
        return new VenueResponse(
            Id: model.Id,
            Name: model.Name,
            Description: model.Description,
            Address: model.Address,
            Capacity: model.Capacity);
    }
}
