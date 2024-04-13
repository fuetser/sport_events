using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;

public class CreateVenueHandler(IVenueRepository venueRepository) : IRequestHandler<CreateVenueCommand, VenueModel>
{
    private readonly IVenueRepository _venueRepository = venueRepository;

    public Task<VenueModel> Handle(CreateVenueCommand request, CancellationToken cancellationToken)
    {
        if (request.VenueCreateRequest.Capacity <= 0)
        {
            throw new ArgumentException("Capacity must be a positive integer");
        }

        var venueModel = new VenueModel
        {
            Id = Guid.NewGuid(),
            Name = request.VenueCreateRequest.Name,
            Description = request.VenueCreateRequest.Description,
            Address = request.VenueCreateRequest.Address,
            Capacity = request.VenueCreateRequest.Capacity,
        };
        return _venueRepository.CreateVenue(venueModel);
    }
}
