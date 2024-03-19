using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;

namespace SportEvents.Application.Services;
public class VenueService(IVenueRepository venueRepository) : IVenueService
{
    private readonly IVenueRepository _venueRepository = venueRepository;

    public bool CreateVenue(VenueCreateRequest request)
    {
        return _venueRepository.CreateVenue(request);
    }

    public bool DeleteVenue(int venueId)
    {
        return _venueRepository.DeleteVenue(venueId);
    }

    public VenueResponse? GetVenueById(int venueId)
    {
        return _venueRepository.GetVenueById(venueId);
    }

    public IList<VenueResponse> GetVenues()
    {
        return _venueRepository.GetVenues();
    }

    public IList<VenueResponse> GetVenuesByEventId(int eventId)
    {
        return _venueRepository.GetVenuesByEventId(eventId);
    }

    public bool UpdateVenue(VenueUpdateRequest request)
    {
        return _venueRepository.UpdateVenue(request);
    }
}
