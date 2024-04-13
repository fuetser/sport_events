using MediatR;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Queries;
public class GetTeamQuery : IRequest<TeamModel>
{
    public Guid TeamId { get; set; }
}
