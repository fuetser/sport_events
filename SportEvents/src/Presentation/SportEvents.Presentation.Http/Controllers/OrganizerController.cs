using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return NotFound(new { detail = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { detail = ex.Message });
        }
    }

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

    [HttpPatch("{organizerId}")]
    public IActionResult UpdateOrganizer(string organizerId, OrganizerUpdateRequest request)
    {
        try
        {
            var organizerModel = OrganizerMapper.OrganizerUpdateToModel(request);
            organizerModel = _organizerService.UpdateOrganizer(new Guid(organizerId), organizerModel);

            return Ok(organizerModel);
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

    [HttpDelete("{organizerId}")]
    public IActionResult DeleteOrganizer(string organizerId)
    {
        try
        {
            _organizerService.DeleteOrganizer(new Guid(organizerId));

            return Ok(new { id = organizerId });
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
