[HttpPost]
public IActionResult CreateTeam(TeamCreateRequest request)
{
    try
    {
        var success = _teamService.CreateTeam(request);
        if (success)
        {
            // Return the created team object
            var createdTeam = _teamService.GetTeamById(request.Id);
            return Created($"/api/v1/teams/{createdTeam.Id}", createdTeam);
        }
        return BadRequest(new { errors = new List<string> { "Failed to create team." } });
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