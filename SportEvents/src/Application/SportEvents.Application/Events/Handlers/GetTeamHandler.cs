using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Queries;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;
public class GetTeamHandler(ITeamRepository teamRepository) : IRequestHandler<GetTeamQuery, TeamModel>
{
    private readonly ITeamRepository _teamRepository = teamRepository;

    public async Task<TeamModel> Handle(GetTeamQuery request, CancellationToken cancellationToken)
    {
        return await _teamRepository.GetTeamById(request.TeamId);
    }
}
