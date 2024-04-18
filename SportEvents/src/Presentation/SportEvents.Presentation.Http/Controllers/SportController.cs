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
[Route("/api/v1/sports")]
public class SportController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("{sportId}")]
    public async Task<ActionResult<SportResponse>> GetSportById(string sportId)
    {
        try
        {
            var sportModel = await _mediator.Send(new GetSportQuery { SportId = new Guid(sportId) });
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
    public async Task<ActionResult<SportResponse>> CreateSport([FromBody] SportCreateRequest request)
    {
        try
        {
            var sportModel = SportMapper.SportCreateToModel(request);
            sportModel = await _mediator.Send(new CreateSportCommand { SportCreateRequest = request });
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
    public async Task<ActionResult<SportResponse>> UpdateSport(string sportId, SportUpdateRequest request)
    {
        try
        {
            var sportModel = SportMapper.SportUpdateToModel(request);
            sportModel = await _mediator.Send(new UpdateSportCommand { SportId = new Guid(sportId), SportUpdateRequest = request });
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
    public async Task<ActionResult<string>> DeleteSport(string sportId)
    {
        try
        {
            await _mediator.Send(new DeleteSportCommand { SportId = new Guid(sportId) });

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
