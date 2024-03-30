using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Requests;

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
            var success = _teamService.CreateTeam(request);
            return success ? Created() : BadRequest(new { errors = new List<string> { "Failed to create team." } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpPatch("{teamId}")]
    public IActionResult UpdateTeam(int teamId, TeamUpdateRequest request)
    {
        try
        {
            // Ensure the request ID matches the route parameter ID
            if (teamId != request.Id)
            {
                return BadRequest(new { errors = new List<string> { "Team ID mismatch between route parameter and request body." } });
            }

            var success = _teamService.UpdateTeam(request);
            if (success)
            {
                // Return the updated team object
                var updatedTeam = _teamService.GetTeamById(teamId);
                return Ok(updatedTeam);
            }

            return BadRequest(new { errors = new List<string> { "Failed to update team." } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }
}