using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;
using System;
using System.Collections.Generic;

namespace SportEvents.Presentation.Http.Controllers
{
    [ApiController]
    [Route("/api/v1/participants")]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpPost]
        public IActionResult CreateParticipant([FromBody] ParticipantCreateRequest request)
        {
            try
            {
                var success = _participantService.CreateParticipant(request);
                if (success)
                {
                    return Created($"/api/v1/participants/{request.Id}", new { id = request.Id, name = request.Name });
                }
                return BadRequest(new { errors = new List<string> { "Failed to create participant." } });
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

        [HttpPatch("{participantId}")]
        public IActionResult UpdateParticipant(int participantId, [FromBody] ParticipantUpdateRequest request)
        {
            try
            {
                request.Id = participantId;
                var success = _participantService.UpdateParticipant(request);
                if (success)
                {
                    return Ok(new { id = participantId, name = request.Name });
                }
                return BadRequest(new { errors = new List<string> { "Failed to update participant." } });
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
                if (success)
                {
                    return Ok(new { message = "Участник удален" });
                }
                return BadRequest(new { errors = new List<string> { "Failed to delete participant." } });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }
    }
}
