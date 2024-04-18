using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return NotFound(new { detail = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { detail = ex.Message });
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

    [HttpDelete("{sportId}")]
    public IActionResult DeleteSport(string sportId)
    {
        try
        {
            _sportService.DeleteSport(new Guid(sportId));

            return Ok(new { id = sportId });
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
