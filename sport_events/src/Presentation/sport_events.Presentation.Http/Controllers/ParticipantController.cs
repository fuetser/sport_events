using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Requests;

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
            var success = _participantService.CreateParticipant(request);
            return success ? Created() : BadRequest(new { errors = new List<string> { "Failed to create participant." } });
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
            var participants = _participantService.GetParticipants();
            return Ok(participants);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpPatch("")]
    public IActionResult UpdateParticipant(ParticipantUpdateRequest request)
    {
        try
        {
            var success = _participantService.UpdateParticipant(request);
            return success ? Ok() : BadRequest(new { errors = new List<string> { "Failed to update participant." } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpDelete("{participantId}")]
    public IActionResult DeleteParticipant(int participantId)
    {
        try
        {
            var success = _participantService.DeleteParticipant(participantId);
            return success
                ? Ok(new { message = "Участник удален" })
                : BadRequest(new { errors = new List<string> { "Failed to delete participant." } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }
}
