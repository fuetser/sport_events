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

    public SportModel GetSportById(Guid sportId)
    {
        Sport sport = _context.Sports.Find(sportId) ?? throw new NotFoundException($"Sport with id {sportId} not found");
        return SportMapper.EntityToModel(sport);
    }

    public SportModel CreateSport(SportModel model)
    {
        Sport sport = SportMapper.ModelToEntity(model);

        _context.Sports.Add(sport);
        _context.SaveChanges();

        return model;
    }

    public SportModel UpdateSport(Guid sportId, SportModel model)
    {
        var sport = _context.Sports.Find(sportId) ?? throw new NotFoundException($"Sport with id {sportId} not found");

        sport.Name = model.Name;
        sport.Description = model.Description;

        _context.SaveChanges();

        return SportMapper.EntityToModel(sport);
    }

    public void DeleteSport(Guid sportId)
    {
        Sport sport = _context.Sports.Find(sportId) ?? throw new NotFoundException($"Sport with id {sportId} not found");
        _context.Sports.Remove(sport);
        _context.SaveChanges();
    }
}
