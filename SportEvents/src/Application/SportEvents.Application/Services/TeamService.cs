using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Services;
public class TeamService(ITeamRepository teamRepository) : ITeamService
{
    private readonly ITeamRepository _teamRepository = teamRepository;

    public Task<TeamModel> CreateTeam(TeamModel model)
    {
        return _teamRepository.CreateTeam(model);
    }

    public void DeleteTeam(Guid teamId)
    {
        _teamRepository.DeleteTeam(teamId);
    }

    public Task<TeamModel> GetTeamById(Guid teamId)
    {
        return _teamRepository.GetTeamById(teamId);
    }

    public Task<TeamModel> UpdateTeam(Guid teamId, TeamModel model)
    {
        return _teamRepository.UpdateTeam(teamId, model);
    }
}
