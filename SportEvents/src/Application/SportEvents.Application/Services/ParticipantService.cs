using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Services;
public class ParticipantService(IParticipantRepository participantRepository) : IParticipantService
{
    private readonly IParticipantRepository _participantRepository = participantRepository;

    public ParticipantModel GetParticipantById(Guid participantId)
    {
        return _participantRepository.GetParticipantById(participantId);
    }

    public ParticipantModel CreateParticipant(ParticipantModel model)
    {
        return _participantRepository.CreateParticipant(model);
    }

    public ParticipantModel UpdateParticipant(Guid participantId, ParticipantModel model)
    {
        return _participantRepository.UpdateParticipant(participantId, model);
    }

    public void DeleteParticipant(Guid participantId)
    {
        _participantRepository.DeleteParticipant(participantId);
    }
}
