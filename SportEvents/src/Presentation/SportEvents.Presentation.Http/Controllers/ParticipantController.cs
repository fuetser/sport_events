using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Events.Queries;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.DTOs;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Presentation.Http.Controllers;
[ApiController]
[Route("/api/v1/participants")]
public class ParticipantController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("{participantId}")]
    public async Task<ActionResult<ParticipantResponse>> GetParticipantById(string participantId)
    {
        try
        {
            var participantModel = await _mediator.Send(new GetParticipantQuery { ParticipantId = new Guid(participantId) });
            var participantResponse = ParticipantMapper.ModelToReponse(participantModel);

            return Ok(participantResponse);
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
    public async Task<ActionResult<ParticipantResponse>> CreateParticipant([FromBody] ParticipantCreateRequest request)
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
            return StatusCode(500, new { detail = ex.Message });
        }
    }

    [HttpPatch("{participantId}")]
    public async Task<ActionResult<ParticipantResponse>> UpdateParticipant(string participantId, ParticipantUpdateRequest request)
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
            return NotFound(new { detail = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { detail = ex.Message });
        }
    }

    [HttpDelete("{participantId}")]
    public async Task<ActionResult<string>> DeleteParticipant(string participantId)
    {
        try
        {
            await _mediator.Send(new DeleteParticipantCommand { ParticipantId = new Guid(participantId) });

            return Ok(participantId);
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
