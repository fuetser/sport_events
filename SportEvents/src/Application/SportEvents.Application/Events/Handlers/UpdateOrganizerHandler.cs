using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;
public class UpdateOrganizerHandler(IOrganizerRepository organizerRepository) : IRequestHandler<UpdateOrganizerCommand, OrganizerModel>
{
    private readonly IOrganizerRepository _organizerRepository = organizerRepository;

    public Task<OrganizerModel> Handle(UpdateOrganizerCommand request, CancellationToken cancellationToken)
    {
        var organizerModel = new OrganizerModel
        {
            Id = Guid.Empty,
            Name = request.OrganizerUpdateRequest.Name,
            Description = request.OrganizerUpdateRequest.Description,
            Email = request.OrganizerUpdateRequest.Email,
            Phone = request.OrganizerUpdateRequest.Phone,
        };
        return _organizerRepository.UpdateOrganizer(request.OrganizerId, organizerModel);
    }
}
