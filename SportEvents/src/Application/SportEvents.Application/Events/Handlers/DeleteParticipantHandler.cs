using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;

namespace SportEvents.Application.Events.Handlers;

public class DeleteParticipantHandler(IParticipantRepository participantRepository) : IRequestHandler<DeleteParticipantCommand, Guid>
{
    private readonly IParticipantRepository _participantRepository = participantRepository;

    public Task<Guid> Handle(DeleteParticipantCommand request, CancellationToken cancellationToken)
    {
        return _participantRepository.DeleteParticipant(request.ParticipantId);
    }
}
