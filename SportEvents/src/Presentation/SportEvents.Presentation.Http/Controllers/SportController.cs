using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Contracts;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.DTOs;
using SportEvents.Infrastructure.Persistence.Mappers;

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
            var sportModels = _sportService.GetSports();
            var sportResponses = sportModels.Select(s => SportMapper.ModelToReponse(s)).ToList();

            return Ok(sportResponses);
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
            var sportModel = SportMapper.SportCreateToModel(request);
            sportModel = _sportService.CreateSport(sportModel);
            var sportResponse = SportMapper.ModelToReponse(sportModel);

            return Ok(sportResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpPatch("{sportId}")]
    public IActionResult UpdateSport(string sportId, SportUpdateRequest request)
    {
        try
        {
            var sportModel = SportMapper.SportUpdateToModel(request);
            sportModel = _sportService.UpdateSport(new Guid(sportId), sportModel);
            var sportResponse = SportMapper.ModelToReponse(sportModel);

            return Ok(sportResponse);
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

    [HttpDelete("{sportId}")]
    public IActionResult DeleteSport(string sportId)
    {
        try
        {
            _sportService.DeleteSport(new Guid(sportId));

            return Ok(sportId);
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

    [HttpGet("{sportId}")]
    public IActionResult GetSportById(string sportId)
    {
        try
        {
            var sportModel = _sportService.GetSportById(new Guid(sportId));
            var sportResponse = SportMapper.ModelToReponse(sportModel);

            return Ok(sportResponse);
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

    [HttpGet("event/{eventId}")]
    public IActionResult GetSportsByEventId(string eventId)
    {
        try
        {
            var sportModels = _sportService.GetSportsByEventId(new Guid(eventId));
            var sportResponses = sportModels.Select(s => SportMapper.ModelToReponse(s)).ToArray();

            return Ok(sportResponses);
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

    [HttpGet("team/{teamId}")]
    public IActionResult GetSportByTeamId(string teamId)
    {
        try
        {
            var sportModel = _sportService.GetSportByTeamId(new Guid(teamId));
            var sportResponse = SportMapper.ModelToReponse(sportModel);

            return Ok(sportResponse);
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
