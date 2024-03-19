using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;

namespace SportEvents.Application.Services;
public class ParticipantService(IParticipantRepository participantRepository) : IParticipantService
{
    private readonly IParticipantRepository _participantRepository = participantRepository;

    public bool CreateParticipant(ParticipantCreateRequest request)
    {
        return _participantRepository.CreateParticipant(request);
    }

    public bool DeleteParticipant(int participantId)
    {
        return _participantRepository.DeleteParticipant(participantId);
    }

    public ParticipantResponse? GetParticipantById(int participantId)
    {
        return _participantRepository.GetParticipantById(participantId);
    }

    public IList<ParticipantResponse> GetParticipants()
    {
        return _participantRepository.GetParticipants();
    }

    public IList<ParticipantResponse> GetParticipantsByEventId(int eventId)
    {
        return _participantRepository.GetParticipantsByEventId(eventId);
    }

    public IList<ParticipantResponse> GetParticipantsByTeamId(int teamId)
    {
        return _participantRepository.GetParticipantsByTeamId(teamId);
    }

    public bool UpdateParticipant(ParticipantUpdateRequest request)
    {
        return _participantRepository.UpdateParticipant(request);
    }
}
