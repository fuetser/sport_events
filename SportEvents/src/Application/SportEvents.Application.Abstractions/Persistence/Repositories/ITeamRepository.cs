using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface ITeamRepository
{
    IList<TeamModel> GetTeams();

    TeamModel GetTeamById(Guid teamId);

    IList<TeamModel> GetTeamsByParticipantId(Guid participantId);

    TeamModel CreateTeam(TeamModel model);

    TeamModel UpdateTeam(Guid teamId, TeamModel model);

    void DeleteTeam(Guid teamId);
}
