using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Contracts;
public interface IVenueService
{
    Task<IList<VenueModel>> GetVenues();

    Task<IList<VenueModel>> GetVenuesByEventId(Guid eventId);

    Task<VenueModel> GetVenueById(Guid venueId);

    Task<VenueModel> CreateVenue(VenueModel model);

    Task<VenueModel> UpdateVenue(Guid venueId, VenueModel model);

    void DeleteVenue(Guid venueId);
}