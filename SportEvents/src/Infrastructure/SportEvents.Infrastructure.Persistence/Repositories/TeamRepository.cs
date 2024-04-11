using SportEvents.Application.Abstractions.Persistence.Repositories;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.Entities;
using SportEvents.Application.Models.Models;
using SportEvents.Infrastructure.Persistence.Contexts;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Infrastructure.Persistence.Repositories;
public class TeamRepository(ApplicationDbContext context) : ITeamRepository
{
    private readonly ApplicationDbContext _context = context;

    public TeamModel CreateTeam(TeamModel model)
    {
        try
        {
            Team team = TeamMapper.ModelToEntity(model);

            _context.Teams.Add(team);
            _context.SaveChanges();

            return model;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public void DeleteTeam(Guid teamId)
    {
        try
        {
            Team team = _context.Teams.Find(teamId) ?? throw new NotFoundException();

            _context.Teams.Remove(team);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public TeamModel GetTeamById(Guid teamId)
    {
        try
        {
            Team team = _context.Teams.Find(teamId) ?? throw new NotFoundException();
            return TeamMapper.EntityToModel(team);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public IList<TeamModel> GetTeams()
    {
        try
        {
            var teamModels = _context.Teams.ToList();
            return ConvertTeamsToModels(teamModels);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public IList<TeamModel> GetTeamsByParticipantId(Guid participantId)
    {
        try
        {
            var targetParticipant = _context.Participants.Find(participantId) ?? throw new NotFoundException();

            return ConvertTeamsToModels(targetParticipant.Teams);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public TeamModel UpdateTeam(Guid teamId, TeamModel model)
    {
        try
        {
            Team team = _context.Teams.Find(teamId) ?? throw new NotFoundException();

            team.Name = model.Name;
            team.Description = model.Description;
            team.SportId = model.SportId;

            _context.SaveChanges();

            return model;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    private List<TeamModel> ConvertTeamsToModels(IList<Team> teams)
    {
        var teamModels = new List<TeamModel>(teams.Count);
        foreach (var team in teams)
        {
            if (team is null)
                continue;

            teamModels.Add(TeamMapper.EntityToModel(team));
        }

        return teamModels;
    }
}
