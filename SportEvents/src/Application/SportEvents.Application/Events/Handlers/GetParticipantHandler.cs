using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Queries;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;
public class GetParticipantHandler(IParticipantRepository participantRepository) : IRequestHandler<GetParticipantQuery, ParticipantModel>
{
    private readonly IParticipantRepository _participantRepository = participantRepository;

    public async Task<ParticipantModel> Handle(GetParticipantQuery request, CancellationToken cancellationToken)
    {
        return await _participantRepository.GetParticipantById(request.ParticipantId);
    }
}
