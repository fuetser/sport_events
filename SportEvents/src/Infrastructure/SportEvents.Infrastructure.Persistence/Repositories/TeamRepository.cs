using Microsoft.EntityFrameworkCore;
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

    public async Task<TeamModel> CreateTeam(TeamModel model)
    {
        try
        {
            Team team = TeamMapper.ModelToEntity(model);

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return model;
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<Guid> DeleteTeam(Guid teamId)
    {
        try
        {
            Team team = await _context.Teams.FindAsync(teamId) ?? throw new NotFoundException($"Team with id {teamId} not found");

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return teamId;
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

    public async Task<TeamModel> GetTeamById(Guid teamId)
    {
        try
        {
            Team team = await _context.Teams.FindAsync(teamId) ?? throw new NotFoundException($"Team with id {teamId} not found");
            return TeamMapper.EntityToModel(team);
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

    public async Task<IList<TeamModel>> GetTeams()
    {
        try
        {
            var teamModels = await _context.Teams.ToListAsync();
            return ConvertTeamsToModels(teamModels);
        }
        catch (Exception)
        {
            throw new InternalServerException();
        }
    }

    public async Task<IList<TeamModel>> GetTeamsByParticipantId(Guid participantId)
    {
        try
        {
            var targetParticipant = await _context.Participants.FindAsync(participantId) ?? throw new NotFoundException($"Participant with id {participantId} not found");

            return ConvertTeamsToModels(targetParticipant.Teams);
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

    public async Task<TeamModel> UpdateTeam(Guid teamId, TeamModel model)
    {
        try
        {
            Team team = await _context.Teams.FindAsync(teamId) ?? throw new NotFoundException($"Team with id {teamId} not found");

            team.Name = model.Name;
            team.Description = model.Description;
            team.SportId = model.SportId;

            await _context.SaveChangesAsync();

            return TeamMapper.EntityToModel(team);
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
