using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Contracts;
public interface IOrganizerService
{
    IList<OrganizerModel> GetOrganizers();

    IList<OrganizerModel> GetOrganizersByEventId(Guid eventId);

    OrganizerModel GetOrganizerById(Guid organizerId);

    OrganizerModel CreateOrganizer(OrganizerModel model);

    OrganizerModel UpdateOrganizer(Guid organizerId, OrganizerModel model);

    void DeleteOrganizer(Guid organizerId);
}
