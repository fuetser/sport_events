using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Queries;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;
public class GetVenueHandler(IVenueRepository venueRepository) : IRequestHandler<GetVenueQuery, VenueModel>
{
    private readonly IVenueRepository _venueRepository = venueRepository;

    public async Task<VenueModel> Handle(GetVenueQuery request, CancellationToken cancellationToken)
    {
        return await _venueRepository.GetVenueById(request.VenueId);
    }
}
