using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Models;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;
using SportEvents.Infrastructure.Persistence.Contexts;

namespace SportEvents.Infrastructure.Persistence.Repositories;
public class SportRepository(ApplicationDbContext context) : ISportRepository
{
    private readonly ApplicationDbContext _context = context;

    public bool CreateSport(SportCreateRequest request)
    {
        try
        {
            var sportModel = new SportModel(
                name: request.Name,
                description: request.Description);

            _context.Sports.Add(sportModel);
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DeleteSport(int sportId)
    {
        try
        {
            var sportModel = _context.Sports.Find(sportId);
            if (sportModel is null)
                return false;

            _context.Sports.Remove(sportModel);
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public SportResponse? GetSportById(int sportId)
    {
        try
        {
            var sportModel = _context.Sports.Find(sportId);
            return sportModel is null
                ? null
                : new SportResponse(
                Id: sportModel.Id,
                Name: sportModel.Name,
                Description: sportModel.Description);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public IList<SportResponse> GetSports()
    {
        try
        {
            var sportModels = _context.Sports.ToList();
            return ConvertSportModelsToResponses(sportModels);
        }
        catch
        {
            return [];
        }
    }

    public IList<SportResponse> GetSportsByEventId(int eventId)
    {
        try
        {
            var targetEvent = _context.Events.Find(eventId);
            if (targetEvent is null)
                return [];

            return ConvertSportModelsToResponses(targetEvent.Sports);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public SportResponse? GetSportByTeamId(int teamId)
    {
        try
        {
            var targetTeam = _context.Teams.Find(teamId);
            return targetTeam is null
                ? null
                : new SportResponse(
                Id: targetTeam.SportId,
                Name: targetTeam.Sport.Name,
                Description: targetTeam.Sport.Description);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public bool UpdateSport(SportUpdateRequest request)
    {
        try
        {
            var sportModel = _context.Sports.Find(request.Id);
            if (sportModel is null)
                return false;

            sportModel.Name = request.Name;
            sportModel.Description = request.Description;

            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private List<SportResponse> ConvertSportModelsToResponses(IList<SportModel> sportModels)
    {
        var sportResponses = new List<SportResponse>(sportModels.Count);
        foreach (var sportModel in sportModels)
        {
            if (sportModel is null)
                continue;

            sportResponses.Add(
                new SportResponse(
                    Id: sportModel.Id,
                    Name: sportModel.Name,
                    Description: sportModel.Description));
        }

        return sportResponses;
    }
}
