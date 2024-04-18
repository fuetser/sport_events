using SportEvents.Application.Models.DTOs;
using SportEvents.Application.Models.Entities;
using SportEvents.Application.Models.Models;

namespace SportEvents.Infrastructure.Persistence.Mappers;
public class ParticipantMapper
{
    public static Participant ModelToEntity(ParticipantModel model)
    {
        return new Participant
        {
            Id = model.Id,
            Name = model.Name,
            DateOfBirth = model.DateOfBirth,
            Email = model.Email,
            Phone = model.Phone,
            Gender = model.Gender,
            EventId = model.EventId,
            TeamId = model.TeamId,
        };
    }

    public static ParticipantModel EntityToModel(Participant participant)
    {
        return new ParticipantModel
        {
            Id = participant.Id,
            Name = participant.Name,
            DateOfBirth = participant.DateOfBirth,
            Email = participant.Email,
            Phone = participant.Phone,
            Gender = participant.Gender,
            EventId = participant.EventId,
            TeamId = participant.TeamId,
        };
    }

    public static ParticipantModel ParticipantCreateToModel(ParticipantCreateRequest request)
    {
        return new ParticipantModel
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            DateOfBirth = request.DateOfBirth,
            Email = request.Email,
            Phone = request.Phone,
            Gender = request.Gender,
            EventId = request.EventId,
            TeamId = request.TeamId,
        };
    }

    public static ParticipantModel ParticipantUpdateToModel(ParticipantUpdateRequest request)
    {
        return new ParticipantModel
        {
            Id = Guid.Empty,
            Name = request.Name,
            DateOfBirth = request.DateOfBirth,
            Email = request.Email,
            Phone = request.Phone,
            Gender = request.Gender,
            EventId = request.EventId,
            TeamId = request.TeamId,
        };
    }

    public static ParticipantResponse ModelToReponse(ParticipantModel model)
    {
        return new ParticipantResponse(
            Id: model.Id,
            Name: model.Name,
            DateOfBirth: model.DateOfBirth,
            Email: model.Email,
            Phone: model.Phone,
            Gender: model.Gender,
            EventId: model.EventId,
            TeamId: model.TeamId);
    }
}
