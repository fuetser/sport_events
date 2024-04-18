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
        Venue venue = VenueMapper.ModelToEntity(model);

        _context.Venues.Add(venue);
        await _context.SaveChangesAsync();

        return model;
    }

    public async Task<Guid> DeleteVenue(Guid venueId)
    {
        Venue venue = await _context.Venues.FindAsync(venueId) ?? throw new NotFoundException($"Venue with id {venueId} not found");

        _context.Venues.Remove(venue);
        await _context.SaveChangesAsync();

        return venueId;
    }

    public async Task<VenueModel> GetVenueById(Guid venueId)
    {
        Venue venue = await _context.Venues.FindAsync(venueId) ?? throw new NotFoundException($"Venue with id {venueId} not found");
        return VenueMapper.EntityToModel(venue);
    }

    public async Task<VenueModel> UpdateVenue(Guid venueId, VenueModel model)
    {
        Venue venue = await _context.Venues.FindAsync(venueId) ?? throw new NotFoundException($"Venue with id {venueId} not found");

        venue.Name = model.Name;
        venue.Description = model.Description;
        venue.Address = model.Address;
        venue.Capacity = model.Capacity;

        await _context.SaveChangesAsync();

        return VenueMapper.EntityToModel(venue);
    }
}
