using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface IOrganizerRepository
{
    Task<OrganizerModel> GetOrganizerById(Guid organizerId);

    Task<OrganizerModel> CreateOrganizer(OrganizerModel model);

    Task<OrganizerModel> UpdateOrganizer(Guid organizerId, OrganizerModel model);

    Task<Guid> DeleteOrganizer(Guid organizerId);
}