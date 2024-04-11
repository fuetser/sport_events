﻿using SportEvents.Application.Models.Models;

namespace SportEvents.Application.Contracts;
public interface IParticipantService
{
    IList<ParticipantModel> GetParticipants();

    IList<ParticipantModel> GetParticipantsByEventId(Guid eventId);

    IList<ParticipantModel> GetParticipantsByTeamId(Guid teamId);

    ParticipantModel GetParticipantById(Guid participantId);

    ParticipantModel CreateParticipant(ParticipantModel model);

    ParticipantModel UpdateParticipant(Guid participantId, ParticipantModel model);

    void DeleteParticipant(Guid participantId);
}
