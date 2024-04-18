using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Contracts;
public interface IParticipantService
{
    Task<ParticipantModel> GetParticipantById(Guid participantId);

    Task<ParticipantModel> CreateParticipant(ParticipantModel model);

    Task<ParticipantModel> UpdateParticipant(Guid participantId, ParticipantModel model);

    void DeleteParticipant(Guid participantId);
}
