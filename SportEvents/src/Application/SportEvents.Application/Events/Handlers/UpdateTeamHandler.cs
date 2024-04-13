using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;

public class UpdateTeamHandler(ITeamRepository teamRepository) : IRequestHandler<UpdateTeamCommand, TeamModel>
{
    private readonly ITeamRepository _teamRepository = teamRepository;

    public Task<TeamModel> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
    {
        var teamModel = new TeamModel
        {
            Id = Guid.Empty,
            Name = request.TeamUpdateRequest.Name,
            Description = request.TeamUpdateRequest.Description,
            SportId = request.TeamUpdateRequest.SportId,
        };
        return _teamRepository.UpdateTeam(request.TeamId, teamModel);
    }
}
