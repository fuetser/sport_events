using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Requests;

namespace SportEvents.Presentation.Http.Controllers;

[ApiController]
[Route("/api/v1/sports")]
public class SportController(ISportService sportService) : ControllerBase
{
    private readonly ISportService _sportService = sportService;

    [HttpGet]
    public IActionResult GetSports()
    {
        try
        {
            var sports = _sportService.GetSports();
            return Ok(sports);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpPost]
    public IActionResult CreateSport([FromBody] SportCreateRequest request)
    {
        try
        {
            var success = _sportService.CreateSport(request);
            return success ? Created() : BadRequest(new { errors = new List<string> { "Failed to create sport." } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpPatch("")]
    public IActionResult UpdateSport(SportUpdateRequest request)
    {
        try
        {
            var success = _sportService.UpdateSport(request);
            return success ? Ok() : BadRequest(new { errors = new List<string> { "Failed to update sport." } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpDelete("{sportId}")]
    public IActionResult DeleteSport(int sportId)
    {
        try
        {
            var success = _sportService.DeleteSport(sportId);
            return success ? Ok(new { message = "Sport deleted" }) : BadRequest(new { errors = new List<string> { "Failed to delete sport." } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }
}
