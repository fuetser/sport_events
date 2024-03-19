﻿using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;

namespace SportEvents.Application.Contracts;
public interface IParticipantService
{
    IList<ParticipantResponse> GetParticipants();

    IList<ParticipantResponse> GetParticipantsByEventId(int eventId);

    IList<ParticipantResponse> GetParticipantsByTeamId(int teamId);

    ParticipantResponse? GetParticipantById(int participantId);

    bool CreateParticipant(ParticipantCreateRequest request);

    bool UpdateParticipant(ParticipantUpdateRequest request);

    bool DeleteParticipant(int participantId);
}
