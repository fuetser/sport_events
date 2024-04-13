using MediatR;

namespace SportEvents.Application.Events.Commands;

internal class DeleteParticipantCommand : IRequest
{
    public Guid ParticipantId { get; set; }
}