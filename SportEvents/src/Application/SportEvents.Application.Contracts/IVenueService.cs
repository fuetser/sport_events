using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Contracts;
public interface IVenueService
{
    IList<VenueModel> GetVenues();

    IList<VenueModel> GetVenuesByEventId(Guid eventId);

    VenueModel GetVenueById(Guid venueId);

    VenueModel CreateVenue(VenueModel model);

    VenueModel UpdateVenue(Guid venueId, VenueModel model);

    void DeleteVenue(Guid venueId);
}