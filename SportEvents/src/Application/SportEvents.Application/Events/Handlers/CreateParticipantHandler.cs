using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;

public class CreateParticipantHandler : IRequestHandler<CreateParticipantCommand, ParticipantModel>
{
    private readonly IParticipantRepository _participantRepository;

    public CreateParticipantHandler(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public async Task<ParticipantModel> Handle(CreateParticipantCommand request, CancellationToken cancellationToken)
    {
        var participant = new ParticipantModel
        {
            // Initialize the ParticipantModel properties from request.ParticipantCreateRequest
        };
        return await _participantRepository.CreateParticipant(participant);
    }
}
