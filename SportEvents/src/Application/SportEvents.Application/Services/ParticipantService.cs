using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Services;
public class ParticipantService(IParticipantRepository participantRepository) : IParticipantService
{
    private readonly IParticipantRepository _participantRepository = participantRepository;

    public Task<ParticipantModel> CreateParticipant(ParticipantModel model)
    {
        return _participantRepository.CreateParticipant(model);
    }

    public void DeleteParticipant(Guid participantId)
    {
        _participantRepository.DeleteParticipant(participantId);
    }

    public Task<ParticipantModel> GetParticipantById(Guid participantId)
    {
        return _participantRepository.GetParticipantById(participantId);
    }

    public Task<IList<ParticipantModel>> GetParticipants()
    {
        return _participantRepository.GetParticipants();
    }

    public Task<IList<ParticipantModel>> GetParticipantsByEventId(Guid eventId)
    {
        return _participantRepository.GetParticipantsByEventId(eventId);
    }

    public Task<IList<ParticipantModel>> GetParticipantsByTeamId(Guid teamId)
    {
        return _participantRepository.GetParticipantsByTeamId(teamId);
    }

    public Task<ParticipantModel> UpdateParticipant(Guid participantId, ParticipantModel model)
    {
        return _participantRepository.UpdateParticipant(participantId, model);
    }
}
