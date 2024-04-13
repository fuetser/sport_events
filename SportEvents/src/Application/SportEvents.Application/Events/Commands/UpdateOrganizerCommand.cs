using MediatR;
using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Commands;
public class UpdateOrganizerCommand : IRequest<OrganizerModel>
{
    public Guid OrganizerId { get; set; }

    public OrganizerUpdateRequest OrganizerUpdateRequest { get; set; } = null!;
}
