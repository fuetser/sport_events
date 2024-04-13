using MediatR;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Queries;
public class GetOrganizerQuery : IRequest<OrganizerModel>
{
    public Guid OrganizerId { get; set; }
}
