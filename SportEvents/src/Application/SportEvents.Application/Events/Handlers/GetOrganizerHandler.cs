using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Queries;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;
public class GetOrganizerHandler(IOrganizerRepository organizerRepository) : IRequestHandler<GetOrganizerQuery, OrganizerModel>
{
    private readonly IOrganizerRepository _organizerRepository = organizerRepository;

    public async Task<OrganizerModel> Handle(GetOrganizerQuery request, CancellationToken cancellationToken)
    {
        return await _organizerRepository.GetOrganizerById(request.OrganizerId);
    }
}
