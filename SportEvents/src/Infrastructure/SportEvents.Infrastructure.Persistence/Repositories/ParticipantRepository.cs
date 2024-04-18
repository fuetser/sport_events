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
        Participant participant = ParticipantMapper.ModelToEntity(model);

        _context.Participants.Add(participant);
        await _context.SaveChangesAsync();

        return model;
    }

    public async Task<Guid> DeleteParticipant(Guid participantId)
    {
        Participant participant = await _context.Participants.FindAsync(participantId) ?? throw new NotFoundException($"Participant with id {participantId} not found");
        _context.Participants.Remove(participant);
        await _context.SaveChangesAsync();

        return participantId;
    }

    public async Task<ParticipantModel> GetParticipantById(Guid participantId)
    {
        Participant participant = await _context.Participants.FindAsync(participantId) ?? throw new NotFoundException($"Participant with id {participantId} not found");
        return ParticipantMapper.EntityToModel(participant);
    }

    public async Task<ParticipantModel> UpdateParticipant(Guid participantId, ParticipantModel model)
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
}
