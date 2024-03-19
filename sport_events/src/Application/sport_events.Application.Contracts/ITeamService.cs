using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;

namespace SportEvents.Application.Contracts;
public interface ITeamService
{
    IList<TeamResponse> GetTeams();

    TeamResponse? GetTeamById(int teamId);

    IList<TeamResponse> GetTeamsByParticipantId(int participantId);

    bool CreateTeam(TeamCreateRequest request);

    bool UpdateTeam(TeamUpdateRequest request);

    bool DeleteTeam(int teamId);
}
