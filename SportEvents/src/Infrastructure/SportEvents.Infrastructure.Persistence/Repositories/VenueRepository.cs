using Microsoft.EntityFrameworkCore;
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

    public async Task<VenueModel> CreateVenue(VenueModel model)
    {
        try
        {
            Venue venue = VenueMapper.ModelToEntity(model);

            _context.Venues.Add(venue);
            await _context.SaveChangesAsync();

            return model;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<Guid> DeleteVenue(Guid venueId)
    {
        try
        {
            Venue venue = await _context.Venues.FindAsync(venueId) ?? throw new NotFoundException($"Venue with id {venueId} not found");

            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();

            return venueId;
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

    public async Task<VenueModel> GetVenueById(Guid venueId)
    {
        try
        {
            Venue venue = await _context.Venues.FindAsync(venueId) ?? throw new NotFoundException($"Venue with id {venueId} not found");
            return VenueMapper.EntityToModel(venue);
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

    public async Task<IList<VenueModel>> GetVenues()
    {
        try
        {
            var venueModels = await _context.Venues.ToListAsync();
            return ConvertVenuesToModels(venueModels);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<IList<VenueModel>> GetVenuesByEventId(Guid eventId)
    {
        try
        {
            var targetEvent = await _context.Events.FindAsync(eventId) ?? throw new NotFoundException($"Event with id {eventId} not found");
            return ConvertVenuesToModels(targetEvent.Venues);
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

    public async Task<VenueModel> UpdateVenue(Guid venueId, VenueModel model)
    {
        try
        {
            Venue venue = await _context.Venues.FindAsync(venueId) ?? throw new NotFoundException($"Venue with id {venueId} not found");

            venue.Name = model.Name;
            venue.Description = model.Description;
            venue.Address = model.Address;
            venue.Capacity = model.Capacity;

            await _context.SaveChangesAsync();

            return VenueMapper.EntityToModel(venue);
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
