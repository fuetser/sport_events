using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.Entities;
using SportEvents.Application.Models.Models;
using SportEvents.Infrastructure.Persistence.Contexts;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Infrastructure.Persistence.Repositories;
public class VenueRepository(ApplicationDbContext context) : IVenueRepository
{
    private readonly ApplicationDbContext _context = context;

    public VenueModel CreateVenue(VenueModel model)
    {
        try
        {
            Venue venue = VenueMapper.ModelToEntity(model);

            _context.Venues.Add(venue);
            _context.SaveChanges();

            return model;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public void DeleteVenue(Guid venueId)
    {
        try
        {
            Venue venue = _context.Venues.Find(venueId) ?? throw new NotFoundException();

            _context.Venues.Remove(venue);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public VenueModel GetVenueById(Guid venueId)
    {
        try
        {
            Venue venue = _context.Venues.Find(venueId) ?? throw new NotFoundException();
            return VenueMapper.EntityToModel(venue);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public IList<VenueModel> GetVenues()
    {
        try
        {
            var venueModels = _context.Venues.ToList();
            return ConvertVenuesToModels(venueModels);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public IList<VenueModel> GetVenuesByEventId(Guid eventId)
    {
        try
        {
            var targetEvent = _context.Events.Find(eventId) ?? throw new NotFoundException();
            return ConvertVenuesToModels(targetEvent.Venues);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public VenueModel UpdateVenue(Guid venueId, VenueModel model)
    {
        try
        {
            Venue venue = _context.Venues.Find(venueId) ?? throw new NotFoundException();

            venue.Name = model.Name;
            venue.Description = model.Description;
            venue.Address = model.Address;
            venue.Capacity = model.Capacity;

            _context.SaveChanges();

            return model;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    private List<VenueModel> ConvertVenuesToModels(IList<Venue> venues)
    {
        var venueModels = new List<VenueModel>(venues.Count);
        foreach (var venue in venues)
        {
            if (venue is null)
                continue;

            venueModels.Add(VenueMapper.EntityToModel(venue));
        }

        return venueModels;
    }
}
