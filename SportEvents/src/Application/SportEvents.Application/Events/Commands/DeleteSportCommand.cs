using MediatR;

namespace SportEvents.Application.Events.Commands;

public class DeleteSportCommand : IRequest<Guid>
{
    public Guid SportId { get; set; }
}
