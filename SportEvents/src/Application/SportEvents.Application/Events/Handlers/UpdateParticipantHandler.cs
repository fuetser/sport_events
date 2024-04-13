using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;

public class UpdateParticipantHandler : IRequestHandler<UpdateParticipantCommand, ParticipantModel>
{
    private readonly IParticipantRepository _participantRepository;

    public UpdateParticipantHandler(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public async Task<ParticipantModel> Handle(UpdateParticipantCommand request, CancellationToken cancellationToken)
    {
        var participant = new ParticipantModel
        {
            // Initialize the ParticipantModel properties from request.ParticipantUpdateRequest
        };
        return await _participantRepository.UpdateParticipant(request.ParticipantId, participant);
    }
}
