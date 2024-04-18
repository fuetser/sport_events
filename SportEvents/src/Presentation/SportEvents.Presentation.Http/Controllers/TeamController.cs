using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportEvents.Application.Contracts;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.DTOs;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Presentation.Http.Controllers;
[ApiController]
[Route("/api/v1/teams")]
public class TeamController(ITeamService teamService) : ControllerBase
{
    private readonly ITeamService _teamService = teamService;

    [HttpGet("{teamId}")]
    public IActionResult GetTeamById(string teamId)
    {
        try
        {
            var teamModel = _teamService.GetTeamById(new Guid(teamId));
            var teamResponse = TeamMapper.ModelToReponse(teamModel);

            return Ok(teamResponse);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { detail = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { detail = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult CreateTeam(TeamCreateRequest request)
    {
        try
        {
            var teamModel = TeamMapper.TeamCreateToModel(request);
            teamModel = _teamService.CreateTeam(teamModel);
            var teamResponse = TeamMapper.ModelToReponse(teamModel);

            return Ok(teamResponse);
        }
        catch (DbUpdateException ex)
        {
            var message = "Bad request";

            if (ex.InnerException is not null)
                message = message = ex.InnerException.Message.Split("\r\n")[0];

            return BadRequest(new { detail = message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { detail = ex.Message });
        }
    }

    [HttpPatch("{teamId}")]
    public IActionResult UpdateTeam(string teamId, TeamUpdateRequest request)
    {
        try
        {
            var teamModel = TeamMapper.TeamUpdateToModel(request);
            teamModel = _teamService.UpdateTeam(new Guid(teamId), teamModel);
            var teamResponse = TeamMapper.ModelToReponse(teamModel);

            return Ok(teamResponse);
        }
        catch (DbUpdateException ex)
        {
            var message = "Bad request";

            if (ex.InnerException is not null)
                message = ex.InnerException.Message.Split("\r\n")[0];

            return BadRequest(new { detail = message });
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { detail = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { detail = ex.Message });
        }
    }

    [HttpDelete("{teamId}")]
    public IActionResult DeleteTeam(string teamId)
    {
        try
        {
            _teamService.DeleteTeam(new Guid(teamId));

            return Ok(new { id = teamId });
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { detail = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { detail = ex.Message });
        }
    }
}