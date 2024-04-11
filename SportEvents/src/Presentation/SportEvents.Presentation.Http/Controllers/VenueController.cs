using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public IActionResult GetVenues()
    {
        try
        {
            var venueModels = _venueService.GetVenues();
            var venueResponses = venueModels.Select(v => VenueMapper.ModelToReponse(v)).ToList();

            return Ok(venueResponses);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
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
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
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
        catch (NotFoundException ex)
        {
            return NotFound(new { errors = new List<string> { ex.Message } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpDelete("{venueId}")]
    public IActionResult DeleteVenue(string venueId)
    {
        try
        {
            _venueService.DeleteVenue(new Guid(venueId));

            return Ok(venueId);
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
            return NotFound(new { errors = new List<string> { ex.Message } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpGet("event/{eventId}")]
    public IActionResult GetVenuesByEventId(string eventId)
    {
        try
        {
            var venueModels = _venueService.GetVenuesByEventId(new Guid(eventId));
            var venueResponses = venueModels.Select(v => VenueMapper.ModelToReponse(v)).ToList();

            return Ok(venueResponses);
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
