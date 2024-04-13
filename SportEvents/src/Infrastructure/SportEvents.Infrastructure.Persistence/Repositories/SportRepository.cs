using Microsoft.EntityFrameworkCore;
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
        try
        {
            Sport sport = SportMapper.ModelToEntity(model);

            _context.Sports.Add(sport);
            await _context.SaveChangesAsync();

            return model;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<Guid> DeleteSport(Guid sportId)
    {
        try
        {
            Sport sport = await _context.Sports.FindAsync(sportId) ?? throw new NotFoundException($"Sport with id {sportId} not found");
            _context.Sports.Remove(sport);
            await _context.SaveChangesAsync();

            return sportId;
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

    public async Task<SportModel> GetSportById(Guid sportId)
    {
        try
        {
            Sport sport = await _context.Sports.FindAsync(sportId) ?? throw new NotFoundException($"Sport with id {sportId} not found");
            return SportMapper.EntityToModel(sport);
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

    public async Task<IList<SportModel>> GetSports()
    {
        try
        {
            var sportModels = await _context.Sports.ToListAsync();
            return ConvertSportsToModels(sportModels);
        }
        catch
        {
            throw new InternalServerException();
        }
    }

    public async Task<IList<SportModel>> GetSportsByEventId(Guid eventId)
    {
        try
        {
            var targetEvent = await _context.Events.FindAsync(eventId) ?? throw new NotFoundException($"Event with id {eventId} not found");
            return ConvertSportsToModels(targetEvent.Sports);
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

    public async Task<SportModel> GetSportByTeamId(Guid teamId)
    {
        try
        {
            var targetTeam = await _context.Teams.FindAsync(teamId) ?? throw new NotFoundException($"Team with id {teamId} not found");
            return SportMapper.EntityToModel(targetTeam.Sport);
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

    public async Task<SportModel> UpdateSport(Guid sportId, SportModel model)
    {
        try
        {
            var sport = await _context.Sports.FindAsync(sportId) ?? throw new NotFoundException($"Sport with id {sportId} not found");

            sport.Name = model.Name;
            sport.Description = model.Description;

            await _context.SaveChangesAsync();

            return SportMapper.EntityToModel(sport);
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

    private List<SportModel> ConvertSportsToModels(IList<Sport> sports)
    {
        var sportModels = new List<SportModel>(sports.Count);
        foreach (var sport in sports)
        {
            if (sport is null)
                continue;

            sportModels.Add(SportMapper.EntityToModel(sport));
        }

        return sportModels;
    }
}
