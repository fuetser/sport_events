using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.DTOs;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Presentation.Http.Controllers;
[ApiController]
[Route("/api/v1/teams")]
public class TeamController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateTeam(TeamCreateRequest request)
    {
        try
        {
            var teamModel = TeamMapper.TeamCreateToModel(request);

            teamModel = await _mediator.Send(new CreateTeamCommand { TeamCreateRequest = request });
            var teamResponse = TeamMapper.ModelToReponse(teamModel);

            return Ok(teamResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpPatch("{teamId}")]
    public async Task<IActionResult> UpdateTeam(string teamId, TeamUpdateRequest request)
    {
        try
        {
            var teamModel = TeamMapper.TeamUpdateToModel(request);

            teamModel = await _mediator.Send(new UpdateTeamCommand { TeamId = new Guid(teamId), TeamUpdateRequest = request });
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

    // [HttpGet("{teamId}")]
    // public IActionResult GetTeamById(string teamId)
    // {
    //    try
    //    {
    //        var teamModel = _teamService.GetTeamById(new Guid(teamId));
    //        var teamResponse = TeamMapper.ModelToReponse(teamModel);

    // return Ok(teamResponse);
    //    }
    //    catch (NotFoundException ex)
    //    {
    //        return NotFound(new { errors = new List<string> { ex.Message } });
    //    }
    //    catch (Exception ex)
    //    {
    //        return StatusCode(500, new { errors = new List<string> { ex.Message } });
    //    }
    // }
    [HttpDelete("{teamId}")]
    public async Task<IActionResult> DeleteTeam(string teamId)
    {
        try
        {
            await _mediator.Send(new DeleteTeamCommand { TeamId = new Guid(teamId) });

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