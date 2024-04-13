using MediatR;

namespace SportEvents.Application.Events.Commands;
internal class DeleteEventCommand : IRequest
{
    public Guid EventId { get; set; }
}
