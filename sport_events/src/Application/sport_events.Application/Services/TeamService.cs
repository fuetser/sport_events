using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;

namespace SportEvents.Application.Services;
public class TeamService(ITeamRepository teamRepository) : ITeamService
{
    private readonly ITeamRepository _teamRepository = teamRepository;

    public bool CreateTeam(TeamCreateRequest request)
    {
        return _teamRepository.CreateTeam(request);
    }

    public bool DeleteTeam(int teamId)
    {
        return _teamRepository.DeleteTeam(teamId);
    }

    public TeamResponse? GetTeamById(int teamId)
    {
        return _teamRepository.GetTeamById(teamId);
    }

    public IList<TeamResponse> GetTeams()
    {
        return _teamRepository.GetTeams();
    }

    public IList<TeamResponse> GetTeamsByParticipantId(int participantId)
    {
        return _teamRepository.GetTeamsByParticipantId(participantId);
    }

    public bool UpdateTeam(TeamUpdateRequest request)
    {
        return _teamRepository.UpdateTeam(request);
    }
}
