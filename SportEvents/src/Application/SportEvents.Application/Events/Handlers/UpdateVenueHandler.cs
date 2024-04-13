using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;

public class UpdateVenueHandler(IVenueRepository venueRepository) : IRequestHandler<UpdateVenueCommand, VenueModel>
{
    private readonly IVenueRepository _venueRepository = venueRepository;

    public Task<VenueModel> Handle(UpdateVenueCommand request, CancellationToken cancellationToken)
    {
        if (request.VenueUpdateRequest.Capacity <= 0)
        {
            throw new ArgumentException("Capacity must be a positive integer");
        }

        var venueModel = new VenueModel
        {
            Id = Guid.Empty,
            Name = request.VenueUpdateRequest.Name,
            Description = request.VenueUpdateRequest.Description,
            Address = request.VenueUpdateRequest.Address,
            Capacity = request.VenueUpdateRequest.Capacity,
        };
        return _venueRepository.UpdateVenue(request.VenueId, venueModel);
    }
}
