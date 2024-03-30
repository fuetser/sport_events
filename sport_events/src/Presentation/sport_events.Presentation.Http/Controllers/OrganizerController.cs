using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Requests;

namespace SportEvents.Presentation.Http.Controllers;

[ApiController]
[Route("/api/v1/organizers")]
public class OrganizerController(IOrganizerService organizerService) : ControllerBase
{
    private readonly IOrganizerService _organizerService = organizerService;

    [HttpPost]
    public IActionResult CreateOrganizer(OrganizerCreateRequest request)
    {
        try
        {
            var success = _organizerService.CreateOrganizer(request);
            return success ? Created() : BadRequest(new { errors = new List<string> { "Failed to create organizer." } });
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
            return organizer != null ? Ok(organizer) : NotFound(new { errors = new List<string> { "Organizer not found." } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpPatch("")]
    public IActionResult UpdateOrganizer(OrganizerUpdateRequest request)
    {
        try
        {
            var success = _organizerService.UpdateOrganizer(request);
            return success ? Ok() : BadRequest(new { errors = new List<string> { "Failed to update organizer." } });
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
            return success
                ? Ok(new { message = "Organizer deleted" })
                : BadRequest(new { errors = new List<string> { "Failed to delete organizer." } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }
}
