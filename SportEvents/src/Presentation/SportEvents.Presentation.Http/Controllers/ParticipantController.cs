using Microsoft.AspNetCore.Mvc;
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
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpGet]
    public IActionResult GetParticipants()
    {
        try
        {
            var participantModels = _participantService.GetParticipants();
            var participantResponses = participantModels.Select(p => ParticipantMapper.ModelToReponse(p)).ToArray();

            return Ok(participantResponses);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
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
    public IActionResult DeleteParticipant(string participantId)
    {
        try
        {
            _participantService.DeleteParticipant(new Guid(participantId));

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

    [HttpGet("event/{eventId}")]
    public IActionResult GetParticipantsByEventId(string eventId)
    {
        try
        {
            var participantModels = _participantService.GetParticipantsByEventId(new Guid(eventId));
            var participantResponses = participantModels.Select(p => ParticipantMapper.ModelToReponse(p)).ToArray();

            return Ok(participantResponses);
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

    [HttpGet("team/{eventId}")]
    public IActionResult GetParticipantsByTeamId(string teamId)
    {
        try
        {
            var participantModels = _participantService.GetParticipantsByTeamId(new Guid(teamId));
            var participantResponses = participantModels.Select(p => ParticipantMapper.ModelToReponse(p)).ToArray();

            return Ok(participantResponses);
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
            return NotFound(new { errors = new List<string> { ex.Message } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }
}
