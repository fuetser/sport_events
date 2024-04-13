using MediatR;

namespace SportEvents.Application.Events.Commands;

public class DeleteParticipantCommand : IRequest<Guid>
{
    public Guid ParticipantId { get; set; }
}