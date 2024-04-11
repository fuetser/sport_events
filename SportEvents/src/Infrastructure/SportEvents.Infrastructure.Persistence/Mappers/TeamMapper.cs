using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Entities;
using SportEvents.Application.Models.Models;

namespace SportEvents.Infrastructure.Persistence.Mappers;
public class TeamMapper
{
    public static Team ModelToEntity(TeamModel model)
    {
        return new Team
        {
            Name = model.Name,
            Description = model.Description,
            SportId = model.SportId,
        };
    }

    public static TeamModel EntityToModel(Team team)
    {
        return new TeamModel
        {
            Name = team.Name,
            Description = team.Description,
            SportId = team.SportId,
        };
    }

    public static TeamModel TeamCreateToModel(TeamCreateRequest request)
    {
        return new TeamModel
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            SportId = request.SportId,
        };
    }

    public static TeamModel TeamUpdateToModel(TeamUpdateRequest request)
    {
        return new TeamModel
        {
            Id = Guid.Empty,
            Name = request.Name,
            Description = request.Description,
            SportId = request.SportId,
        };
    }

    public static TeamResponse ModelToReponse(TeamModel model)
    {
        return new TeamResponse(
            Id: model.Id,
            Name: model.Name,
            Description: model.Description,
            SportId: model.SportId);
    }
}
