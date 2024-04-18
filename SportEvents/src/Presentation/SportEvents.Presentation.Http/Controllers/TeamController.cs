using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Events.Queries;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.DTOs;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Presentation.Http.Controllers;
[ApiController]
[Route("/api/v1/teams")]
public class TeamController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("{teamId}")]
    public async Task<ActionResult<TeamResponse>> GetTeamById(string teamId)
    {
        try
        {
            var teamModel = await _mediator.Send(new GetTeamQuery { TeamId = new Guid(teamId) });
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
    public async Task<ActionResult<TeamResponse>> CreateTeam(TeamCreateRequest request)
    {
        try
        {
            var teamModel = TeamMapper.TeamCreateToModel(request);
            teamModel = await _mediator.Send(new CreateTeamCommand { TeamCreateRequest = request });
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
        catch (Exception ex)
        {
            return StatusCode(500, new { detail = ex.Message });
        }
    }

    [HttpPatch("{teamId}")]
    public async Task<ActionResult<TeamResponse>> UpdateTeam(string teamId, TeamUpdateRequest request)
    {
        try
        {
            var teamModel = TeamMapper.TeamUpdateToModel(request);
            teamModel = await _mediator.Send(new UpdateTeamCommand { TeamId = new Guid(teamId), TeamUpdateRequest = request });
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
    public async Task<ActionResult<string>> DeleteTeam(string teamId)
    {
        try
        {
            await _mediator.Send(new DeleteTeamCommand { TeamId = new Guid(teamId) });

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