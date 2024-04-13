using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.DTOs;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Presentation.Http.Controllers;
[ApiController]
[Route("/api/v1/sports")]
public class SportController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateSport([FromBody] SportCreateRequest request)
    {
        try
        {
            var sportModel = SportMapper.SportCreateToModel(request);

            sportModel = await _mediator.Send(new CreateSportCommand { SportCreateRequest = request });
            var sportResponse = SportMapper.ModelToReponse(sportModel);

            return Ok(sportResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpPatch("{sportId}")]
    public async Task<IActionResult> UpdateSport(string sportId, SportUpdateRequest request)
    {
        try
        {
            var sportModel = SportMapper.SportUpdateToModel(request);

            sportModel = await _mediator.Send(new UpdateSportCommand { SportId = new Guid(sportId), SportUpdateRequest = request });
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
    public async Task<IActionResult> DeleteSport(string sportId)
    {
        try
        {
            await _mediator.Send(new DeleteSportCommand { SportId = new Guid(sportId) });

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

    // [HttpGet("{sportId}")]
    // public IActionResult GetSportById(string sportId)
    // {
    //    try
    //    {
    //        var sportModel = _sportService.GetSportById(new Guid(sportId));
    //        var sportResponse = SportMapper.ModelToReponse(sportModel);

    // return Ok(sportResponse);
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
}
