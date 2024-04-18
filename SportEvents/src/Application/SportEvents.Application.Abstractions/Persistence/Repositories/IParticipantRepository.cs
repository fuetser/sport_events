using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Abstractions.Persistence.Repositories;
public interface IParticipantRepository
{
    ParticipantModel GetParticipantById(Guid participantId);

    ParticipantModel CreateParticipant(ParticipantModel model);

    ParticipantModel UpdateParticipant(Guid participantId, ParticipantModel model);

    void DeleteParticipant(Guid participantId);
}
