using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;
public class CreateOrganizerHandler(IOrganizerRepository organizerRepository) : IRequestHandler<CreateOrganizerCommand, OrganizerModel>
{
    private readonly IOrganizerRepository _organizerRepository = organizerRepository;

    public Task<OrganizerModel> Handle(CreateOrganizerCommand request, CancellationToken cancellationToken)
    {
        var organizerModel = new OrganizerModel
        {
            Id = Guid.NewGuid(),
            Name = request.OrganizerCreateRequest.Name,
            Description = request.OrganizerCreateRequest.Description,
            Email = request.OrganizerCreateRequest.Email,
            Phone = request.OrganizerCreateRequest.Phone,
        };
        return _organizerRepository.CreateOrganizer(organizerModel);
    }
}
