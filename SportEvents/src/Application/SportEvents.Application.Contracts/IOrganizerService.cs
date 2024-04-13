using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Contracts;
public interface IOrganizerService
{
    Task<IList<OrganizerModel>> GetOrganizers();

    Task<IList<OrganizerModel>> GetOrganizersByEventId(Guid eventId);

    Task<OrganizerModel> GetOrganizerById(Guid organizerId);

    Task<OrganizerModel> CreateOrganizer(OrganizerModel model);

    Task<OrganizerModel> UpdateOrganizer(Guid organizerId, OrganizerModel model);

    void DeleteOrganizer(Guid organizerId);
}
