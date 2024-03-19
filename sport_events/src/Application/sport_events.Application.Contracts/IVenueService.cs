using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;

namespace SportEvents.Application.Contracts;

public interface IVenueService
{
    IList<VenueResponse> GetVenues();

    IList<VenueResponse> GetVenuesByEventId(int eventId);

    VenueResponse? GetVenueById(int venueId);

    bool CreateVenue(VenueCreateRequest request);

    bool UpdateVenue(VenueUpdateRequest request);

    bool DeleteVenue(int venueId);
}