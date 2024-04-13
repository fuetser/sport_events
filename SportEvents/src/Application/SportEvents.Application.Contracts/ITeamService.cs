using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Contracts;
public interface ITeamService
{
    Task<IList<TeamModel>> GetTeams();

    Task<TeamModel> GetTeamById(Guid teamId);

    Task<IList<TeamModel>> GetTeamsByParticipantId(Guid participantId);

    Task<TeamModel> CreateTeam(TeamModel model);

    Task<TeamModel> UpdateTeam(Guid teamId, TeamModel model);

    void DeleteTeam(Guid teamId);
}
