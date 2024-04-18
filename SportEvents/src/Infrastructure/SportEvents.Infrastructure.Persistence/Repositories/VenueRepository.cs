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

    public VenueModel GetVenueById(Guid venueId)
    {
        Venue venue = _context.Venues.Find(venueId) ?? throw new NotFoundException($"Venue with id {venueId} not found");
        return VenueMapper.EntityToModel(venue);
    }

    public VenueModel CreateVenue(VenueModel model)
    {
        Venue venue = VenueMapper.ModelToEntity(model);

        _context.Venues.Add(venue);
        _context.SaveChanges();

        return model;
    }

    public VenueModel UpdateVenue(Guid venueId, VenueModel model)
    {
        Venue venue = _context.Venues.Find(venueId) ?? throw new NotFoundException($"Venue with id {venueId} not found");

        venue.Name = model.Name;
        venue.Description = model.Description;
        venue.Address = model.Address;
        venue.Capacity = model.Capacity;

        _context.SaveChanges();

        return VenueMapper.EntityToModel(venue);
    }

    public void DeleteVenue(Guid venueId)
    {
        Venue venue = _context.Venues.Find(venueId) ?? throw new NotFoundException($"Venue with id {venueId} not found");

        _context.Venues.Remove(venue);
        _context.SaveChanges();
    }
}
