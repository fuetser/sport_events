using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Contracts;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.DTOs;
using SportEvents.Infrastructure.Persistence.Mappers;

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
            var organizerModel = OrganizerMapper.OrganizerCreateToModel(request);
            organizerModel = _organizerService.CreateOrganizer(organizerModel);
            var organizerResponse = OrganizerMapper.ModelToReponse(organizerModel);

            return Ok(organizerResponse);
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
            var organizerModels = _organizerService.GetOrganizers();
            var organizerResponses = organizerModels.Select(m => OrganizerMapper.ModelToReponse(m)).ToArray();

            return Ok(organizerResponses);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpGet("{organizerId}")]
    public IActionResult GetOrganizer(string organizerId)
    {
        try
        {
            var organizerModel = _organizerService.GetOrganizerById(new Guid(organizerId));
            var organizerResponse = OrganizerMapper.ModelToReponse(organizerModel);

            return Ok(organizerResponse);
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

    [HttpPatch("{organizerId}")]
    public IActionResult UpdateOrganizer(string organizerId, OrganizerUpdateRequest request)
    {
        try
        {
            var organizerModel = OrganizerMapper.OrganizerUpdateToModel(request);
            organizerModel = _organizerService.UpdateOrganizer(new Guid(organizerId), organizerModel);

            return Ok(organizerModel);
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

    [HttpDelete("{organizerId}")]
    public IActionResult DeleteOrganizer(string organizerId)
    {
        try
        {
            _organizerService.DeleteOrganizer(new Guid(organizerId));

            return Ok(organizerId);
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

    [HttpGet("events/{eventId}")]
    public IActionResult GetOrganizersByEventId(string eventId)
    {
        try
        {
            var organizerModels = _organizerService.GetOrganizersByEventId(new Guid(eventId));
            var organizerResponses = organizerModels.Select(m => OrganizerMapper.ModelToReponse(m)).ToArray();

            return Ok(organizerResponses);
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
