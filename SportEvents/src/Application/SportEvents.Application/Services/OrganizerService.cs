using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Services;
public class OrganizerService(IOrganizerRepository organizerRepository) : IOrganizerService
{
    private readonly IOrganizerRepository _organizerRepository = organizerRepository;

    public Task<OrganizerModel> CreateOrganizer(OrganizerModel model)
    {
        return _organizerRepository.CreateOrganizer(model);
    }

    public void DeleteOrganizer(Guid organizerId)
    {
        _organizerRepository.DeleteOrganizer(organizerId);
    }

    public Task<OrganizerModel> GetOrganizerById(Guid organizerId)
    {
        return _organizerRepository.GetOrganizerById(organizerId);
    }

    public Task<OrganizerModel> UpdateOrganizer(Guid organizerId, OrganizerModel model)
    {
        return _organizerRepository.UpdateOrganizer(organizerId, model);
    }
}
