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

    public OrganizerModel CreateOrganizer(OrganizerModel model)
    {
        try
        {
            Organizer organizer = OrganizerMapper.ModelToEntity(model);
            _context.Organizers.Add(organizer);
            _context.SaveChanges();

            return model;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public void DeleteOrganizer(Guid organizerId)
    {
        try
        {
            Organizer organizer = _context.Organizers.Find(organizerId) ?? throw new NotFoundException($"Organizer with id {organizerId} not found");
            _context.Organizers.Remove(organizer);
            _context.SaveChanges();
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

    public OrganizerModel GetOrganizerById(Guid organizerId)
    {
        try
        {
            Organizer organizer = _context.Organizers.Find(organizerId) ?? throw new NotFoundException($"Organizer with id {organizerId} not found");
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

    public IList<OrganizerModel> GetOrganizers()
    {
        try
        {
            var organizers = _context.Organizers.ToList();
            return ConvertOrganizersToModels(organizers);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public IList<OrganizerModel> GetOrganizersByEventId(Guid eventId)
    {
        try
        {
            var targetEventModel = _context.Events.Find(eventId) ?? throw new NotFoundException($"Event with id {eventId} not found");
            return ConvertOrganizersToModels(targetEventModel.Organizers);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public OrganizerModel UpdateOrganizer(Guid organizerId, OrganizerModel model)
    {
        try
        {
            Organizer organizer = _context.Organizers.Find(organizerId) ?? throw new NotFoundException($"Organizer with id {organizerId} not found");
            organizer.Name = model.Name;
            organizer.Description = model.Description;
            organizer.Email = model.Email;
            organizer.Phone = model.Phone;

            _context.SaveChanges();

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
