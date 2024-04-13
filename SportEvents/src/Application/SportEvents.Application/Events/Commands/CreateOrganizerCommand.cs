using MediatR;
using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Commands;
public class CreateOrganizerCommand : IRequest<OrganizerModel>
{
    public OrganizerCreateRequest OrganizerCreateRequest { get; set; } = null!;
}
