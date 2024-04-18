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
        Team team = TeamMapper.ModelToEntity(model);

        _context.Teams.Add(team);
        await _context.SaveChangesAsync();

        return model;
    }

    public async Task<Guid> DeleteTeam(Guid teamId)
    {
        Team team = await _context.Teams.FindAsync(teamId) ?? throw new NotFoundException($"Team with id {teamId} not found");

        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();

        return teamId;
    }

    public async Task<TeamModel> GetTeamById(Guid teamId)
    {
        Team team = await _context.Teams.FindAsync(teamId) ?? throw new NotFoundException($"Team with id {teamId} not found");
        return TeamMapper.EntityToModel(team);
    }

    public async Task<TeamModel> UpdateTeam(Guid teamId, TeamModel model)
    {
        Team team = await _context.Teams.FindAsync(teamId) ?? throw new NotFoundException($"Team with id {teamId} not found");

        team.Name = model.Name;
        team.Description = model.Description;
        team.SportId = model.SportId;

        await _context.SaveChangesAsync();

        return TeamMapper.EntityToModel(team);
    }
}
