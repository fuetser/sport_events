using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface ITeamRepository
{
    Task<TeamModel> GetTeamById(Guid teamId);

    Task<TeamModel> CreateTeam(TeamModel model);

    Task<TeamModel> UpdateTeam(Guid teamId, TeamModel model);

    Task<Guid> DeleteTeam(Guid teamId);
}
