using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;

namespace SportEvents.Application.Events.Handlers;
public class DeleteOrganizerHandler(IOrganizerRepository organizerRepository) : IRequestHandler<DeleteOrganizerCommand, Guid>
{
    private readonly IOrganizerRepository _organizerRepository = organizerRepository;

    public Task<Guid> Handle(DeleteOrganizerCommand request, CancellationToken cancellationToken)
    {
        return _organizerRepository.DeleteOrganizer(request.OrganizerId);
    }
}
