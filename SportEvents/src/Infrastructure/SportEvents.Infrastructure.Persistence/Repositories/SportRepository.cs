using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.Entities;
using SportEvents.Application.Models.Models;
using SportEvents.Infrastructure.Persistence.Contexts;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Infrastructure.Persistence.Repositories;
public class SportRepository(ApplicationDbContext context) : ISportRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<SportModel> CreateSport(SportModel model)
    {
        Sport sport = SportMapper.ModelToEntity(model);

        _context.Sports.Add(sport);
        await _context.SaveChangesAsync();

        return model;
    }

    public async Task<Guid> DeleteSport(Guid sportId)
    {
        Sport sport = await _context.Sports.FindAsync(sportId) ?? throw new NotFoundException($"Sport with id {sportId} not found");
        _context.Sports.Remove(sport);
        await _context.SaveChangesAsync();

        return sportId;
    }

    public async Task<SportModel> GetSportById(Guid sportId)
    {
        Sport sport = await _context.Sports.FindAsync(sportId) ?? throw new NotFoundException($"Sport with id {sportId} not found");
        return SportMapper.EntityToModel(sport);
    }

    public async Task<SportModel> UpdateSport(Guid sportId, SportModel model)
    {
        var sport = await _context.Sports.FindAsync(sportId) ?? throw new NotFoundException($"Sport with id {sportId} not found");

        sport.Name = model.Name;
        sport.Description = model.Description;

        await _context.SaveChangesAsync();

        return SportMapper.EntityToModel(sport);
    }
}
