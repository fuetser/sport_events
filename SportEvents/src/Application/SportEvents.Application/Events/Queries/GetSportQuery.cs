using MediatR;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Queries;
public class GetSportQuery : IRequest<SportModel>
{
    public Guid SportId { get; set; }
}
