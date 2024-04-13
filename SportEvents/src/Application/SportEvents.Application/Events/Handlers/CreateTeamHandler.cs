using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;

public class CreateTeamHandler(ITeamRepository teamRepository) : IRequestHandler<CreateTeamCommand, TeamModel>
{
    private readonly ITeamRepository _teamRepository = teamRepository;

    public Task<TeamModel> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var teamModel = new TeamModel
        {
            Id = Guid.NewGuid(),
            Name = request.TeamCreateRequest.Name,
            Description = request.TeamCreateRequest.Description,
            SportId = request.TeamCreateRequest.SportId,
        };
        return _teamRepository.CreateTeam(teamModel);
    }
}
