using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;

namespace SportEvents.Application.Events.Handlers;

public class DeleteTeamHandler(ITeamRepository teamRepository) : IRequestHandler<DeleteTeamCommand, Guid>
{
    private readonly ITeamRepository _teamRepository = teamRepository;

    public Task<Guid> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
        return _teamRepository.DeleteTeam(request.TeamId);
    }
}
