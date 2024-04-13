using MediatR;

namespace SportEvents.Application.Events.Commands;
public class DeleteEventCommand : IRequest<Guid>
{
    public Guid EventId { get; set; }
}
