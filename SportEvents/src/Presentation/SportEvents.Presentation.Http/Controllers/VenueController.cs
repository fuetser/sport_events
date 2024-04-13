using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.DTOs;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Presentation.Http.Controllers;
[ApiController]
[Route("/api/v1/venues")]
public class VenueController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateVenue(VenueCreateRequest request)
    {
        try
        {
            var venueModel = VenueMapper.VenueCreateToModel(request);

            // venueModel = _venueService.CreateVenue(venueModel);
            venueModel = await _mediator.Send(new CreateVenueCommand { VenueCreateRequest = request });
            var venueResponse = VenueMapper.ModelToReponse(venueModel);

            return Ok(venueResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpPatch("{venueId}")]
    public async Task<IActionResult> UpdateVenue(string venueId, VenueUpdateRequest request)
    {
        try
        {
            var venueModel = VenueMapper.VenueUpdateToModel(request);

            venueModel = await _mediator.Send(new UpdateVenueCommand { VenueUpdateRequest = request });
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
    public async Task<IActionResult> DeleteVenue(string venueId)
    {
        try
        {
            await _mediator.Send(new DeleteVenueCommand { VenueId = new Guid(venueId) });

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

    // [HttpGet("{venueId}")]
    // public IActionResult GetVenueById(string venueId)
    // {
    //    try
    //    {
    //        var venueModel = _venueService.GetVenueById(new Guid(venueId));
    //        var venueResponse = VenueMapper.ModelToReponse(venueModel);

    // return Ok(venueResponse);
    //    }
    //    catch (NotFoundException ex)
    //    {
    //        return NotFound(new { errors = new List<string> { ex.Message } });
    //    }
    //    catch (Exception ex)
    //    {
    //        return StatusCode(500, new { errors = new List<string> { ex.Message } });
    //    }
    // }
}
