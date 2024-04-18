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

    public TeamModel GetTeamById(Guid teamId)
    {
        Team team = _context.Teams.Find(teamId) ?? throw new NotFoundException($"Team with id {teamId} not found");
        return TeamMapper.EntityToModel(team);
    }

    public TeamModel CreateTeam(TeamModel model)
    {
        Team team = TeamMapper.ModelToEntity(model);

        _context.Teams.Add(team);
        _context.SaveChanges();

        return model;
    }

    public TeamModel UpdateTeam(Guid teamId, TeamModel model)
    {
        Team team = _context.Teams.Find(teamId) ?? throw new NotFoundException($"Team with id {teamId} not found");

        team.Name = model.Name;
        team.Description = model.Description;
        team.SportId = model.SportId;

        _context.SaveChanges();

        return TeamMapper.EntityToModel(team);
    }

    public void DeleteTeam(Guid teamId)
    {
        Team team = _context.Teams.Find(teamId) ?? throw new NotFoundException($"Team with id {teamId} not found");

        _context.Teams.Remove(team);
        _context.SaveChanges();
    }
}
