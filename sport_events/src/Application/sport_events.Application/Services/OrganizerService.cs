using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;

namespace SportEvents.Application.Services;
public class OrganizerService(IOrganizerRepository organizerRepository) : IOrganizerService
{
    private readonly IOrganizerRepository _organizerRepository = organizerRepository;

    public bool CreateOrganizer(OrganizerCreateRequest request)
    {
        return _organizerRepository.CreateOrganizer(request);
    }

    public bool DeleteOrganizer(int organizerId)
    {
        return _organizerRepository.DeleteOrganizer(organizerId);
    }

    public OrganizerResponse? GetOrganizerById(int organizerId)
    {
        return _organizerRepository.GetOrganizerById(organizerId);
    }

    public IList<OrganizerResponse> GetOrganizers()
    {
        return _organizerRepository.GetOrganizers();
    }

    public IList<OrganizerResponse> GetOrganizersByEventId(int eventId)
    {
        return _organizerRepository.GetOrganizersByEventId(eventId);
    }

    public bool UpdateOrganizer(OrganizerUpdateRequest request)
    {
        return _organizerRepository.UpdateOrganizer(request);
    }
}
