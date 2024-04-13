using MediatR;

namespace SportEvents.Application.Events.Commands;

public class DeleteVenueCommand : IRequest<Guid>
{
    public Guid VenueId { get; set; }
}
