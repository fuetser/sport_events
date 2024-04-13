using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;

namespace SportEvents.Application.Events.Handlers;

public class DeleteParticipantHandler : IRequestHandler<DeleteParticipantCommand>
{
    private readonly IParticipantRepository _participantRepository;

    public DeleteParticipantHandler(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public async Task<Unit> Handle(DeleteParticipantCommand request, CancellationToken cancellationToken)
    {
        await _participantRepository.DeleteParticipant(request.ParticipantId);
        return Unit.Value;
    }
}
