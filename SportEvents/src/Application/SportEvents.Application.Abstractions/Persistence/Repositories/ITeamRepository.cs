using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface ITeamRepository
{
    Task<IList<TeamModel>> GetTeams();

    Task<TeamModel> GetTeamById(Guid teamId);

    Task<IList<TeamModel>> GetTeamsByParticipantId(Guid participantId);

    Task<TeamModel> CreateTeam(TeamModel model);

    Task<TeamModel> UpdateTeam(Guid teamId, TeamModel model);

    Task<Guid> DeleteTeam(Guid teamId);
}
