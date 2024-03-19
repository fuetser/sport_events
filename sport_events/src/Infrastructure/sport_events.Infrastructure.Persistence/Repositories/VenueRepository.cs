using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Models;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;
using SportEvents.Infrastructure.Persistence.Contexts;

namespace SportEvents.Infrastructure.Persistence.Repositories;
public class VenueRepository(ApplicationDbContext context) : IVenueRepository
{
    private readonly ApplicationDbContext _context = context;

    public bool CreateVenue(VenueCreateRequest request)
    {
        try
        {
            var venueModel = new VenueModel(
                name: request.Name,
                description: request.Description,
                address: request.Address,
                capacity: request.Capacity);

            _context.Venues.Add(venueModel);
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DeleteVenue(int venueId)
    {
        try
        {
            var venueModel = _context.Venues.Find(venueId);
            if (venueModel is null)
                return false;

            _context.Venues.Remove(venueModel);
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public VenueResponse? GetVenueById(int venueId)
    {
        try
        {
            var venueModel = _context.Venues.Find(venueId);
            return venueModel is null
                ? null
                : new VenueResponse(
                Id: venueModel.Id,
                Name: venueModel.Name,
                Description: venueModel.Description,
                Address: venueModel.Address,
                Capacity: venueModel.Capacity);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public IList<VenueResponse> GetVenues()
    {
        try
        {
            var venueModels = _context.Venues.ToList();
            return ConvertVenueModelsToResponses(venueModels);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public IList<VenueResponse> GetVenuesByEventId(int eventId)
    {
        try
        {
            var targetEvent = _context.Events.Find(eventId);
            if (targetEvent is null)
                return [];

            return ConvertVenueModelsToResponses(targetEvent.Venues);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public bool UpdateVenue(VenueUpdateRequest request)
    {
        try
        {
            var venueModel = _context.Venues.Find(request.Id);
            if (venueModel is null)
                return false;

            venueModel.Name = request.Name;
            venueModel.Description = request.Description;
            venueModel.Address = request.Address;
            venueModel.Capacity = request.Capacity;

            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private List<VenueResponse> ConvertVenueModelsToResponses(IList<VenueModel> venueModels)
    {
        var venueResponses = new List<VenueResponse>(venueModels.Count);
        foreach (var venueModel in venueModels)
        {
            if (venueModel is null)
                continue;

            venueResponses.Add(
                new VenueResponse(
                    Id: venueModel.Id,
                    Name: venueModel.Name,
                    Description: venueModel.Description,
                    Address: venueModel.Address,
                    Capacity: venueModel.Capacity));
        }

        return venueResponses;
    }
}
