using MediatR;

namespace SportEvents.Application.Events.Commands;

public class DeleteTeamCommand : IRequest<Guid>
{
    public Guid TeamId { get; set; }
}
