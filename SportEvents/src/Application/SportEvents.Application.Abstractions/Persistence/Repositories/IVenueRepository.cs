using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface IVenueRepository
{
    IList<VenueModel> GetVenues();

    IList<VenueModel> GetVenuesByEventId(Guid eventId);

    VenueModel GetVenueById(Guid venueId);

    VenueModel CreateVenue(VenueModel model);

    VenueModel UpdateVenue(Guid venueId, VenueModel model);

    void DeleteVenue(Guid venueId);
}
