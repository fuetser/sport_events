using MediatR;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Queries;
public class GetVenueQuery : IRequest<VenueModel>
{
    public Guid VenueId { get; set; }
}
