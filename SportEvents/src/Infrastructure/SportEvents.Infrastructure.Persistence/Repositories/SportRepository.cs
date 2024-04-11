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

    public SportModel CreateSport(SportModel model)
    {
        try
        {
            Sport sport = SportMapper.ModelToEntity(model);

            _context.Sports.Add(sport);
            _context.SaveChanges();

            return model;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public void DeleteSport(Guid sportId)
    {
        try
        {
            Sport? sport = _context.Sports.Find(sportId);
            if (sport is null)
                throw new NotFoundException();

            _context.Sports.Remove(sport);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public SportModel GetSportById(Guid sportId)
    {
        try
        {
            Sport sport = _context.Sports.Find(sportId) ?? throw new NotFoundException();
            return SportMapper.EntityToModel(sport);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public IList<SportModel> GetSports()
    {
        try
        {
            var sportModels = _context.Sports.ToList();
            return ConvertSportsToModels(sportModels);
        }
        catch
        {
            throw new InternalServerException();
        }
    }

    public IList<SportModel> GetSportsByEventId(Guid eventId)
    {
        try
        {
            var targetEvent = _context.Events.Find(eventId) ?? throw new NotFoundException();
            return ConvertSportsToModels(targetEvent.Sports);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public SportModel GetSportByTeamId(Guid teamId)
    {
        try
        {
            var targetTeam = _context.Teams.Find(teamId) ?? throw new NotFoundException();
            return SportMapper.EntityToModel(targetTeam.Sport);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public SportModel UpdateSport(Guid sportId, SportModel model)
    {
        try
        {
            var sport = _context.Sports.Find(sportId) ?? throw new NotFoundException();

            sport.Name = model.Name;
            sport.Description = model.Description;

            _context.SaveChanges();

            return model;
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
