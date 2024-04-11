using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.Entities;
using SportEvents.Application.Models.Models;
using SportEvents.Infrastructure.Persistence.Contexts;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Infrastructure.Persistence.Repositories;
public class ParticipantRepository(ApplicationDbContext context) : IParticipantRepository
{
    private readonly ApplicationDbContext _context = context;

    public ParticipantModel CreateParticipant(ParticipantModel model)
    {
        try
        {
            Participant? participant = ParticipantMapper.ModelToEntity(model);

            _context.Participants.Add(participant);
            _context.SaveChanges();

            return model;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public void DeleteParticipant(Guid participantId)
    {
        try
        {
            Participant? participant = _context.Participants.Find(participantId) ?? throw new NotFoundException();
            _context.Participants.Remove(participant);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public ParticipantModel GetParticipantById(Guid participantId)
    {
        try
        {
            Participant participant = _context.Participants.Find(participantId) ?? throw new NotFoundException();
            return ParticipantMapper.EntityToModel(participant);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public IList<ParticipantModel> GetParticipants()
    {
        try
        {
            var participants = _context.Participants.ToList();
            return ConvertParticipantsToModels(participants);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public IList<ParticipantModel> GetParticipantsByEventId(Guid eventId)
    {
        try
        {
            EEvent? eevent = _context.Events.Find(eventId) ?? throw new NotFoundException();
            return ConvertParticipantsToModels(eevent.Participants);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public IList<ParticipantModel> GetParticipantsByTeamId(Guid teamId)
    {
        try
        {
            Team? targetTeam = _context.Teams.Find(teamId) ?? throw new NotFoundException();
            return ConvertParticipantsToModels(targetTeam.Participants);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public ParticipantModel UpdateParticipant(Guid participantId, ParticipantModel model)
    {
        try
        {
            var participant = _context.Participants.Find(participantId) ?? throw new NotFoundException();

            participant.Name = model.Name;
            participant.DateOfBirth = model.DateOfBirth;
            participant.Email = model.Email;
            participant.Phone = model.Phone;
            participant.Gender = model.Gender;

            _context.SaveChanges();

            return model;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    private List<ParticipantModel> ConvertParticipantsToModels(IList<Participant> participants)
    {
        var participantModels = new List<ParticipantModel>(participants.Count);
        foreach (var participant in participants)
        {
            if (participant is null)
                continue;

            participantModels.Add(ParticipantMapper.EntityToModel(participant));
        }

        return participantModels;
    }
}
