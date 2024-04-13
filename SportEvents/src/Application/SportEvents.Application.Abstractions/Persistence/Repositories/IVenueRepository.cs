using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface IVenueRepository
{
    Task<IList<VenueModel>> GetVenues();

    Task<IList<VenueModel>> GetVenuesByEventId(Guid eventId);

    Task<VenueModel> GetVenueById(Guid venueId);

    Task<VenueModel> CreateVenue(VenueModel model);

    Task<VenueModel> UpdateVenue(Guid venueId, VenueModel model);

    Task<Guid> DeleteVenue(Guid venueId);
}
