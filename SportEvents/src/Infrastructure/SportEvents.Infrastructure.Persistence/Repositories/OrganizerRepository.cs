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

    public OrganizerModel GetOrganizerById(Guid organizerId)
    {
        Organizer organizer = _context.Organizers.Find(organizerId) ?? throw new NotFoundException($"Organizer with id {organizerId} not found");
        return OrganizerMapper.EntityToModel(organizer);
    }

    public OrganizerModel CreateOrganizer(OrganizerModel model)
    {
        Organizer organizer = OrganizerMapper.ModelToEntity(model);
        _context.Organizers.Add(organizer);
        _context.SaveChanges();

        return model;
    }

    public OrganizerModel UpdateOrganizer(Guid organizerId, OrganizerModel model)
    {
        Organizer organizer = _context.Organizers.Find(organizerId) ?? throw new NotFoundException($"Organizer with id {organizerId} not found");
        organizer.Name = model.Name;
        organizer.Description = model.Description;
        organizer.Email = model.Email;
        organizer.Phone = model.Phone;

        _context.SaveChanges();

        return OrganizerMapper.EntityToModel(organizer);
    }

    public void DeleteOrganizer(Guid organizerId)
    {
        Organizer organizer = _context.Organizers.Find(organizerId) ?? throw new NotFoundException($"Organizer with id {organizerId} not found");
        _context.Organizers.Remove(organizer);
        _context.SaveChanges();
    }
}
