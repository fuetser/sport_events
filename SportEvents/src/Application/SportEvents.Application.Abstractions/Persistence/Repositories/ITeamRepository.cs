using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface ITeamRepository
{
    TeamModel GetTeamById(Guid teamId);

    TeamModel CreateTeam(TeamModel model);

    TeamModel UpdateTeam(Guid teamId, TeamModel model);

    void DeleteTeam(Guid teamId);
}
