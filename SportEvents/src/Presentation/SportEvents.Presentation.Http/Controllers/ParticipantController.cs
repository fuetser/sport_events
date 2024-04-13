using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.DTOs;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Presentation.Http.Controllers;
[ApiController]
[Route("/api/v1/participants")]
public class ParticipantController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateParticipant([FromBody] ParticipantCreateRequest request)
    {
        try
        {
            var participantModel = ParticipantMapper.ParticipantCreateToModel(request);

            participantModel = await _mediator.Send(new CreateParticipantCommand { ParticipantCreateRequest = request });
            var participantResponse = ParticipantMapper.ModelToReponse(participantModel);

            return Ok(participantResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpPatch("{participantId}")]
    public async Task<IActionResult> UpdateParticipant(string participantId, ParticipantUpdateRequest request)
    {
        try
        {
            var participantModel = ParticipantMapper.ParticipantUpdateToModel(request);

            participantModel = await _mediator.Send(new UpdateParticipantCommand { ParticipantId = new Guid(participantId), ParticipantUpdateRequest = request });
            var participantResponse = ParticipantMapper.ModelToReponse(participantModel);

            return Ok(participantResponse);
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

    [HttpDelete("{participantId}")]
    public async Task<IActionResult> DeleteParticipant(string participantId)
    {
        try
        {
            await _mediator.Send(new DeleteParticipantCommand { ParticipantId = new Guid(participantId) });

            return Ok(participantId);
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

    // [HttpGet("{participantId}")]
    // public IActionResult GetParticipantById(string participantId)
    // {
    //    try
    //    {
    //        var participantModel = _participantService.GetParticipantById(new Guid(participantId));
    //        var participantResponse = ParticipantMapper.ModelToReponse(participantModel);

    // return Ok(participantResponse);
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
