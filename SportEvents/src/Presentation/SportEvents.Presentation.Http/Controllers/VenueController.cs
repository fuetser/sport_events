using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportEvents.Application.Contracts;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.DTOs;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Presentation.Http.Controllers;
[ApiController]
[Route("/api/v1/venues")]
public class VenueController(IVenueService venueService) : ControllerBase
{
    private readonly IVenueService _venueService = venueService;

    [HttpGet("{venueId}")]
    public IActionResult GetVenueById(string venueId)
    {
        try
        {
            var venueModel = _venueService.GetVenueById(new Guid(venueId));
            var venueResponse = VenueMapper.ModelToReponse(venueModel);

            return Ok(venueResponse);
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
    public IActionResult CreateVenue(VenueCreateRequest request)
    {
        try
        {
            var venueModel = VenueMapper.VenueCreateToModel(request);
            venueModel = _venueService.CreateVenue(venueModel);
            var venueResponse = VenueMapper.ModelToReponse(venueModel);

            return Ok(venueResponse);
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

    [HttpPatch("{venueId}")]
    public IActionResult UpdateVenue(string venueId, VenueUpdateRequest request)
    {
        try
        {
            var venueModel = VenueMapper.VenueUpdateToModel(request);
            venueModel = _venueService.UpdateVenue(new Guid(venueId), venueModel);
            var venueResponse = VenueMapper.ModelToReponse(venueModel);

            return Ok(venueResponse);
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

    [HttpDelete("{venueId}")]
    public IActionResult DeleteVenue(string venueId)
    {
        try
        {
            _venueService.DeleteVenue(new Guid(venueId));

            return Ok(new { id = venueId });
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
