using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;

namespace SportEvents.Application.Events.Handlers;

public class DeleteVenueHandler(IVenueRepository venueRepository) : IRequestHandler<DeleteVenueCommand, Guid>
{
    private readonly IVenueRepository _venueRepository = venueRepository;

    public Task<Guid> Handle(DeleteVenueCommand request, CancellationToken cancellationToken)
    {
        return _venueRepository.DeleteVenue(request.VenueId);
    }
}
