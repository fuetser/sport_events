using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Models;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;
using SportEvents.Infrastructure.Persistence.Contexts;

namespace SportEvents.Infrastructure.Persistence.Repositories;
public class OrganizerRepository(ApplicationDbContext context) : IOrganizerRepository
{
    private readonly ApplicationDbContext _context = context;

    public bool CreateOrganizer(OrganizerCreateRequest request)
    {
        try
        {
            var organizerModel = new OrganizerModel(
                name: request.Name,
                description: request.Description,
                email: request.Email,
                phone: request.Phone);

            _context.Organizers.Add(organizerModel);
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DeleteOrganizer(int organizerId)
    {
        try
        {
            var organizerModel = _context.Organizers.Find(organizerId);
            if (organizerModel is null)
                return false;

            _context.Organizers.Remove(organizerModel);
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public OrganizerResponse? GetOrganizerById(int organizerId)
    {
        try
        {
            var organizerModel = _context.Organizers.Find(organizerId);
            return organizerModel is null
                ? null
                : new OrganizerResponse(
                Id: organizerModel.Id,
                Name: organizerModel.Name,
                Description: organizerModel.Description,
                Email: organizerModel.Email,
                Phone: organizerModel.Phone);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public IList<OrganizerResponse> GetOrganizers()
    {
        try
        {
            var organizerModels = _context.Organizers.ToList();
            return ConvertOrganizerModelsToResponses(organizerModels);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public IList<OrganizerResponse> GetOrganizersByEventId(int eventId)
    {
        try
        {
            var targetEventModel = _context.Events.Find(eventId);
            if (targetEventModel is null)
                return [];

            return ConvertOrganizerModelsToResponses(targetEventModel.Organizers);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public bool UpdateOrganizer(OrganizerUpdateRequest request)
    {
        try
        {
            var organizerModel = _context.Organizers.Find(request.Id);
            if (organizerModel is null)
                return false;

            organizerModel.Name = request.Name;
            organizerModel.Description = request.Description;
            organizerModel.Email = request.Email;
            organizerModel.Phone = request.Phone;

            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private List<OrganizerResponse> ConvertOrganizerModelsToResponses(IList<OrganizerModel> organizerModels)
    {
        var organizerResponses = new List<OrganizerResponse>(organizerModels.Count);
        foreach (var organizerModel in organizerModels)
        {
            if (organizerModel is null)
                continue;

            organizerResponses.Add(
                new OrganizerResponse(
                    Id: organizerModel.Id,
                    Name: organizerModel.Name,
                    Description: organizerModel.Description,
                    Email: organizerModel.Email,
                    Phone: organizerModel.Phone));
        }

        return organizerResponses;
    }
}
