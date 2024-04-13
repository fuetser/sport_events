using MediatR;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Queries;
public class GetParticipantQuery : IRequest<ParticipantModel>
{
    public Guid ParticipantId { get; set; }
}
