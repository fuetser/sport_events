using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;

public class UpdateParticipantHandler(IParticipantRepository participantRepository) : IRequestHandler<UpdateParticipantCommand, ParticipantModel>
{
    private readonly IParticipantRepository _participantRepository = participantRepository;

    public Task<ParticipantModel> Handle(UpdateParticipantCommand request, CancellationToken cancellationToken)
    {
        var participant = new ParticipantModel
        {
            Id = Guid.Empty,
            Name = request.ParticipantUpdateRequest.Name,
            DateOfBirth = request.ParticipantUpdateRequest.DateOfBirth,
            Email = request.ParticipantUpdateRequest.Email,
            Phone = request.ParticipantUpdateRequest.Phone,
            Gender = request.ParticipantUpdateRequest.Gender,
        };
        return _participantRepository.UpdateParticipant(request.ParticipantId, participant);
    }
}
