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

    public ParticipantModel GetParticipantById(Guid participantId)
    {
        Participant participant = _context.Participants.Find(participantId) ?? throw new NotFoundException($"Participant with id {participantId} not found");
        return ParticipantMapper.EntityToModel(participant);
    }

    public ParticipantModel CreateParticipant(ParticipantModel model)
    {
        Participant participant = ParticipantMapper.ModelToEntity(model);

        _context.Participants.Add(participant);
        _context.SaveChanges();

        return model;
    }

    public ParticipantModel UpdateParticipant(Guid participantId, ParticipantModel model)
    {
        var participant = _context.Participants.Find(participantId) ?? throw new NotFoundException($"Participant with id {participantId} not found");

        participant.Name = model.Name;
        participant.DateOfBirth = model.DateOfBirth;
        participant.Email = model.Email;
        participant.Phone = model.Phone;
        participant.Gender = model.Gender;

        _context.SaveChanges();

        return ParticipantMapper.EntityToModel(participant);
    }

    public void DeleteParticipant(Guid participantId)
    {
        Participant participant = _context.Participants.Find(participantId) ?? throw new NotFoundException($"Participant with id {participantId} not found");
        _context.Participants.Remove(participant);
        _context.SaveChanges();
    }
}
