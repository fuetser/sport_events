using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Services;
public class VenueService(IVenueRepository venueRepository) : IVenueService
{
    private readonly IVenueRepository _venueRepository = venueRepository;

    public VenueModel CreateVenue(VenueModel model)
    {
        return _venueRepository.CreateVenue(model);
    }

    public void DeleteVenue(Guid venueId)
    {
        _venueRepository.DeleteVenue(venueId);
    }

    public VenueModel GetVenueById(Guid venueId)
    {
        return _venueRepository.GetVenueById(venueId);
    }

    public IList<VenueModel> GetVenues()
    {
        return _venueRepository.GetVenues();
    }

    public IList<VenueModel> GetVenuesByEventId(Guid eventId)
    {
        return _venueRepository.GetVenuesByEventId(eventId);
    }

    public VenueModel UpdateVenue(Guid venueId, VenueModel model)
    {
        return _venueRepository.UpdateVenue(venueId, model);
    }
}
