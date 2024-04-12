using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Entities;
using SportEvents.Application.Models.Models;

namespace SportEvents.Infrastructure.Persistence.Mappers;
public class SportMapper
{
    public static Sport ModelToEntity(SportModel model)
    {
        return new Sport
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
        };
    }

    public static SportModel EntityToModel(Sport sport)
    {
        return new SportModel
        {
            Id = sport.Id,
            Name = sport.Name,
            Description = sport.Description,
        };
    }

    public static SportModel SportCreateToModel(SportCreateRequest request)
    {
        return new SportModel
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
        };
    }

    public static SportModel SportUpdateToModel(SportUpdateRequest request)
    {
        return new SportModel
        {
            Id = Guid.Empty,
            Name = request.Name,
            Description = request.Description,
        };
    }

    public static SportResponse ModelToReponse(SportModel model)
    {
        return new SportResponse(
            Id: model.Id,
            Name: model.Name,
            Description: model.Description);
    }
}
