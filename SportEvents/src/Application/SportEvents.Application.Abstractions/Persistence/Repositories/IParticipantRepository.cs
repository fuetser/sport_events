using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface IParticipantRepository
{
    Task<ParticipantModel> GetParticipantById(Guid participantId);

    Task<ParticipantModel> CreateParticipant(ParticipantModel model);

    Task<ParticipantModel> UpdateParticipant(Guid participantId, ParticipantModel model);

    Task<Guid> DeleteParticipant(Guid participantId);
}
