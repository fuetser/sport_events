using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.Entities;
using SportEvents.Application.Models.Models;
using SportEvents.Infrastructure.Persistence.Contexts;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Infrastructure.Persistence.Repositories;
public class OrganizerRepository(ApplicationDbContext context) : IOrganizerRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<OrganizerModel> CreateOrganizer(OrganizerModel model)
    {
        Organizer organizer = OrganizerMapper.ModelToEntity(model);
        _context.Organizers.Add(organizer);
        await _context.SaveChangesAsync();

        return model;
    }

    public async Task<Guid> DeleteOrganizer(Guid organizerId)
    {
        Organizer organizer = await _context.Organizers.FindAsync(organizerId) ?? throw new NotFoundException($"Organizer with id {organizerId} not found");
        _context.Organizers.Remove(organizer);
        await _context.SaveChangesAsync();

        return organizerId;
    }

    public async Task<OrganizerModel> GetOrganizerById(Guid organizerId)
    {
        Organizer organizer = await _context.Organizers.FindAsync(organizerId) ?? throw new NotFoundException($"Organizer with id {organizerId} not found");
        return OrganizerMapper.EntityToModel(organizer);
    }

    public async Task<OrganizerModel> UpdateOrganizer(Guid organizerId, OrganizerModel model)
    {
        Organizer organizer = await _context.Organizers.FindAsync(organizerId) ?? throw new NotFoundException($"Organizer with id {organizerId} not found");
        organizer.Name = model.Name;
        organizer.Description = model.Description;
        organizer.Email = model.Email;
        organizer.Phone = model.Phone;

        await _context.SaveChangesAsync();

        return OrganizerMapper.EntityToModel(organizer);
    }
}
