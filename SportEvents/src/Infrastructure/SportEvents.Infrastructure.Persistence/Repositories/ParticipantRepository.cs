using Microsoft.EntityFrameworkCore;
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

    public async Task<ParticipantModel> CreateParticipant(ParticipantModel model)
    {
        try
        {
            Participant participant = ParticipantMapper.ModelToEntity(model);

            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();

            return model;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<Guid> DeleteParticipant(Guid participantId)
    {
        try
        {
            Participant participant = await _context.Participants.FindAsync(participantId) ?? throw new NotFoundException($"Participant with id {participantId} not found");
            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();

            return participantId;
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<ParticipantModel> GetParticipantById(Guid participantId)
    {
        try
        {
            Participant participant = await _context.Participants.FindAsync(participantId) ?? throw new NotFoundException($"Participant with id {participantId} not found");
            return ParticipantMapper.EntityToModel(participant);
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<IList<ParticipantModel>> GetParticipants()
    {
        try
        {
            var participants = await _context.Participants.ToListAsync();
            return ConvertParticipantsToModels(participants);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public async Task<IList<ParticipantModel>> GetParticipantsByEventId(Guid eventId)
    {
        try
        {
            EEvent targetEvent = await _context.Events.FindAsync(eventId) ?? throw new NotFoundException($"Event with id {eventId} not found");
            return ConvertParticipantsToModels(targetEvent.Participants);
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<IList<ParticipantModel>> GetParticipantsByTeamId(Guid teamId)
    {
        try
        {
            Team targetTeam = await _context.Teams.FindAsync(teamId) ?? throw new NotFoundException($"Team with id {teamId} not found");
            return ConvertParticipantsToModels(targetTeam.Participants);
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<ParticipantModel> UpdateParticipant(Guid participantId, ParticipantModel model)
    {
        try
        {
            var participant = await _context.Participants.FindAsync(participantId) ?? throw new NotFoundException($"Participant with id {participantId} not found");

            participant.Name = model.Name;
            participant.DateOfBirth = model.DateOfBirth;
            participant.Email = model.Email;
            participant.Phone = model.Phone;
            participant.Gender = model.Gender;

            await _context.SaveChangesAsync();

            return ParticipantMapper.EntityToModel(participant);
        }
        catch (NotFoundException)
        {
            throw;
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
