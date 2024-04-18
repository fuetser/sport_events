using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportEvents.Application.Contracts;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.DTOs;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Presentation.Http.Controllers;
[ApiController]
[Route("/api/v1/participants")]
public class ParticipantController(IParticipantService participantService) : ControllerBase
{
    private readonly IParticipantService _participantService = participantService;

    [HttpGet("{participantId}")]
    public IActionResult GetParticipantById(string participantId)
    {
        try
        {
            var participantModel = _participantService.GetParticipantById(new Guid(participantId));
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
    public IActionResult CreateParticipant([FromBody] ParticipantCreateRequest request)
    {
        try
        {
            var participantModel = ParticipantMapper.ParticipantCreateToModel(request);
            participantModel = _participantService.CreateParticipant(participantModel);
            var participantResponse = ParticipantMapper.ModelToReponse(participantModel);

            return Ok(participantResponse);
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

    [HttpPatch("{participantId}")]
    public IActionResult UpdateParticipant(string participantId, ParticipantUpdateRequest request)
    {
        try
        {
            var participantModel = ParticipantMapper.ParticipantUpdateToModel(request);
            participantModel = _participantService.UpdateParticipant(new Guid(participantId), participantModel);
            var participantResponse = ParticipantMapper.ModelToReponse(participantModel);

            return Ok(participantResponse);
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

    [HttpDelete("{participantId}")]
    public IActionResult DeleteParticipant(string participantId)
    {
        try
        {
            _participantService.DeleteParticipant(new Guid(participantId));

            return Ok(new { id = participantId });
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
