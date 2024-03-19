using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Models;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;
using SportEvents.Infrastructure.Persistence.Contexts;

namespace SportEvents.Infrastructure.Persistence.Repositories;
public class TeamRepository(ApplicationDbContext context) : ITeamRepository
{
    private readonly ApplicationDbContext _context = context;

    public bool CreateTeam(TeamCreateRequest request)
    {
        try
        {
            var targetSport = _context.Sports.Find(request.SportId);
            if (targetSport == null)
                return false;

            var teamModel = new TeamModel(
                name: request.Name,
                description: request.Description,
                sportId: request.SportId,
                sport: targetSport);

            _context.Teams.Add(teamModel);
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DeleteTeam(int teamId)
    {
        try
        {
            var teamModel = _context.Teams.Find(teamId);
            if (teamModel == null)
                return false;

            _context.Teams.Remove(teamModel);
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public TeamResponse? GetTeamById(int teamId)
    {
        try
        {
            var teamModel = _context.Teams.Find(teamId);
            return teamModel == null
                ? null
                : new TeamResponse(
                Id: teamModel.Id,
                Name: teamModel.Name,
                Description: teamModel.Description,
                SportId: teamModel.SportId);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public IList<TeamResponse> GetTeams()
    {
        try
        {
            var teamModels = _context.Teams.ToList();
            return ConvertTeamModelsToResponses(teamModels);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public IList<TeamResponse> GetTeamsByParticipantId(int participantId)
    {
        try
        {
            var targetParticipant = _context.Participants.Find(participantId);
            if (targetParticipant is null)
                return [];

            return ConvertTeamModelsToResponses(targetParticipant.Teams);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public bool UpdateTeam(TeamUpdateRequest request)
    {
        try
        {
            var teamModel = _context.Teams.Find(request.Id);
            if (teamModel is null)
                return false;

            teamModel.Name = request.Name;
            teamModel.Description = request.Description;
            teamModel.SportId = request.SportId;

            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private List<TeamResponse> ConvertTeamModelsToResponses(IList<TeamModel> teamModels)
    {
        var teamResponses = new List<TeamResponse>(teamModels.Count);
        foreach (var teamModel in teamModels)
        {
            if (teamModel is null)
                continue;

            teamResponses.Add(
                new TeamResponse(
                    Id: teamModel.Id,
                    Name: teamModel.Name,
                    Description: teamModel.Description,
                    SportId: teamModel.SportId));
        }

        return teamResponses;
    }
}
