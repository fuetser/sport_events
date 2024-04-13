using MediatR;

namespace SportEvents.Application.Events.Commands;
public class DeleteEventCommand : IRequest<string>
{
    public Guid EventId { get; set; }
}
