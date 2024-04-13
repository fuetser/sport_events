using MediatR;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Queries;
public class GetEventQuery : IRequest<EventModel>
{
    public Guid EventId { get; set; }
}
