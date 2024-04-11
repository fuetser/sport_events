using Microsoft.AspNetCore.Mvc;
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
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
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
        catch (NotFoundException ex)
        {
            return NotFound(new { errors = new List<string> { ex.Message } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpGet]
    public IActionResult GetTeams()
    {
        try
        {
            var teamModels = _teamService.GetTeams();
            var teamResponses = teamModels.Select(t => TeamMapper.ModelToReponse(t)).ToList();

            return Ok(teamResponses);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

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
            return NotFound(new { errors = new List<string> { ex.Message } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpGet("participant/{participantId}")]
    public IActionResult GetTeamByParticipantId(string participantId)
    {
        try
        {
            var teamModels = _teamService.GetTeamsByParticipantId(new Guid(participantId));
            var teamResponses = teamModels.Select(t => TeamMapper.ModelToReponse(t)).ToList();

            return Ok(teamResponses);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { errors = new List<string> { ex.Message } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpDelete("{teamId}")]
    public IActionResult DeleteTeam(string teamId)
    {
        try
        {
            _teamService.DeleteTeam(new Guid(teamId));

            return Ok(teamId);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { errors = new List<string> { ex.Message } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }
}