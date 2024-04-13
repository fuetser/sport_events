using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Contracts;
public interface IParticipantService
{
    Task<IList<ParticipantModel>> GetParticipants();

    Task<IList<ParticipantModel>> GetParticipantsByEventId(Guid eventId);

    Task<IList<ParticipantModel>> GetParticipantsByTeamId(Guid teamId);

    Task<ParticipantModel> GetParticipantById(Guid participantId);

    Task<ParticipantModel> CreateParticipant(ParticipantModel model);

    Task<ParticipantModel> UpdateParticipant(Guid participantId, ParticipantModel model);

    void DeleteParticipant(Guid participantId);
}
