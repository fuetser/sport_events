using MediatR;
using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Events.Handlers;

public class CreateParticipantHandler(IParticipantRepository participantRepository) : IRequestHandler<CreateParticipantCommand, ParticipantModel>
{
    private readonly IParticipantRepository _participantRepository = participantRepository;

    public Task<ParticipantModel> Handle(CreateParticipantCommand request, CancellationToken cancellationToken)
    {
        var participant = new ParticipantModel
        {
            Id = Guid.NewGuid(),
            Name = request.ParticipantCreateRequest.Name,
            DateOfBirth = request.ParticipantCreateRequest.DateOfBirth,
            Email = request.ParticipantCreateRequest.Email,
            Phone = request.ParticipantCreateRequest.Phone,
            Gender = request.ParticipantCreateRequest.Gender,
            EventId = request.ParticipantCreateRequest.EventId,
            TeamId = request.ParticipantCreateRequest.TeamId,
        };
        return _participantRepository.CreateParticipant(participant);
    }
}
