using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Contracts;
public interface ITeamService
{
    Task<TeamModel> GetTeamById(Guid teamId);

    Task<TeamModel> CreateTeam(TeamModel model);

    Task<TeamModel> UpdateTeam(Guid teamId, TeamModel model);

    void DeleteTeam(Guid teamId);
}
