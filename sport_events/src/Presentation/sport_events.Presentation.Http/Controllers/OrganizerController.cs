using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;
using System;
using System.Collections.Generic;

namespace SportEvents.Presentation.Http.Controllers
{
    [ApiController]
    [Route("/api/v1/organizers")]
    public class OrganizerController : ControllerBase
    {
        private readonly IOrganizerService _organizerService;

        public OrganizerController(IOrganizerService organizerService)
        {
            _organizerService = organizerService;
        }

        [HttpPost]
        public IActionResult CreateOrganizer(OrganizerCreateRequest request)
        {
            try
            {
                var success = _organizerService.CreateOrganizer(request);
                if (success)
                {
                    return Created($"/api/v1/organizers/{request.Id}", new { id = request.Id, name = request.Name });
                }
                return BadRequest(new { errors = new List<string> { "Failed to create organizer." } });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }

        [HttpGet]
        public IActionResult GetOrganizers()
        {
            try
            {
                var organizers = _organizerService.GetOrganizers();
                return Ok(organizers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }

        [HttpGet("{organizerId}")]
        public IActionResult GetOrganizer(int organizerId)
        {
            try
            {
                var organizer = _organizerService.GetOrganizerById(organizerId);
                if (organizer != null)
                {
                    return Ok(organizer);
                }
                return NotFound(new { errors = new List<string> { "Organizer not found." } });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }

        [HttpPatch("{organizerId}")]
        public IActionResult UpdateOrganizer(int organizerId, OrganizerUpdateRequest request)
        {
            try
            {
                request.Id = organizerId;
                var success = _organizerService.UpdateOrganizer(request);
                if (success)
                {
                    return Ok(new { id = organizerId, name = request.Name });
                }
                return BadRequest(new { errors = new List<string> { "Failed to update organizer." } });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }

        [HttpDelete("{organizerId}")]
        public IActionResult DeleteOrganizer(int organizerId)
        {
            try
            {
                var success = _organizerService.DeleteOrganizer(organizerId);
                if (success)
                {
                    return Ok(new { message = "Organizer deleted" });
                }
                return BadRequest(new { errors = new List<string> { "Failed to delete organizer." } });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }
    }
}
