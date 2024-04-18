using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Services;
public class OrganizerService(IOrganizerRepository organizerRepository) : IOrganizerService
{
    private readonly IOrganizerRepository _organizerRepository = organizerRepository;

    public OrganizerModel GetOrganizerById(Guid organizerId)
    {
        return _organizerRepository.GetOrganizerById(organizerId);
    }

    public OrganizerModel CreateOrganizer(OrganizerModel model)
    {
        return _organizerRepository.CreateOrganizer(model);
    }

    public OrganizerModel UpdateOrganizer(Guid organizerId, OrganizerModel model)
    {
        return _organizerRepository.UpdateOrganizer(organizerId, model);
    }

    public void DeleteOrganizer(Guid organizerId)
    {
        _organizerRepository.DeleteOrganizer(organizerId);
    }
}