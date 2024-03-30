using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Requests;

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
            var venues = _venueService.GetVenues();
            return Ok(venues);
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
            var success = _venueService.CreateVenue(request);
            return success ? Created() : BadRequest(new { errors = new List<string> { "Failed to create venue." } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpPatch("")]
    public IActionResult UpdateVenue(VenueUpdateRequest request)
    {
        try
        {
            var success = _venueService.UpdateVenue(request);
            return success ? Ok() : BadRequest(new { errors = new List<string> { "Failed to update venue." } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpDelete("{venueId}")]
    public IActionResult DeleteVenue(int venueId)
    {
        try
        {
            var success = _venueService.DeleteVenue(venueId);
            return success
                ? Ok(new { message = "Место проведения удалено" })
                : BadRequest(new { errors = new List<string> { "Failed to delete venue." } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }
}
