using MediatR;

namespace SportEvents.Application.Events.Commands;
public class DeleteOrganizerCommand : IRequest<Guid>
{
    public Guid OrganizerId { get; set; }
}
