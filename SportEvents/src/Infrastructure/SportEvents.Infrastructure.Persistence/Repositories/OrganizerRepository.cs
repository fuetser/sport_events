using Microsoft.EntityFrameworkCore;
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
        try
        {
            Organizer organizer = OrganizerMapper.ModelToEntity(model);
            _context.Organizers.Add(organizer);
            await _context.SaveChangesAsync();

            return model;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<Guid> DeleteOrganizer(Guid organizerId)
    {
        try
        {
            Organizer organizer = await _context.Organizers.FindAsync(organizerId) ?? throw new NotFoundException($"Organizer with id {organizerId} not found");
            _context.Organizers.Remove(organizer);
            await _context.SaveChangesAsync();

            return organizerId;
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

    public async Task<OrganizerModel> GetOrganizerById(Guid organizerId)
    {
        try
        {
            Organizer organizer = await _context.Organizers.FindAsync(organizerId) ?? throw new NotFoundException($"Organizer with id {organizerId} not found");
            return OrganizerMapper.EntityToModel(organizer);
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

    public async Task<IList<OrganizerModel>> GetOrganizers()
    {
        try
        {
            var organizers = await _context.Organizers.ToListAsync();
            return ConvertOrganizersToModels(organizers);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<IList<OrganizerModel>> GetOrganizersByEventId(Guid eventId)
    {
        try
        {
            var targetEventModel = await _context.Events.FindAsync(eventId) ?? throw new NotFoundException($"Event with id {eventId} not found");
            return ConvertOrganizersToModels(targetEventModel.Organizers);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<OrganizerModel> UpdateOrganizer(Guid organizerId, OrganizerModel model)
    {
        try
        {
            Organizer organizer = await _context.Organizers.FindAsync(organizerId) ?? throw new NotFoundException($"Organizer with id {organizerId} not found");
            organizer.Name = model.Name;
            organizer.Description = model.Description;
            organizer.Email = model.Email;
            organizer.Phone = model.Phone;

            await _context.SaveChangesAsync();

            return OrganizerMapper.EntityToModel(organizer);
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

    private List<OrganizerModel> ConvertOrganizersToModels(IList<Organizer> organizers)
    {
        var organizerModels = new List<OrganizerModel>(organizers.Count);
        foreach (var organizer in organizers)
        {
            if (organizer is null)
                continue;

            organizerModels.Add(OrganizerMapper.EntityToModel(organizer));
        }

        return organizerModels;
    }
}
