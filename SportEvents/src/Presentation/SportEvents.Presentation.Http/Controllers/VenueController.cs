using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Events.Queries;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.DTOs;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Presentation.Http.Controllers;
[ApiController]
[Route("/api/v1/venues")]
public class VenueController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("{venueId}")]
    public async Task<ActionResult<VenueResponse>> GetVenueById(string venueId)
    {
        try
        {
            var venueModel = await _mediator.Send(new GetVenueQuery { VenueId = new Guid(venueId) });
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
    public async Task<ActionResult<VenueResponse>> CreateVenue(VenueCreateRequest request)
    {
        try
        {
            var venueModel = VenueMapper.VenueCreateToModel(request);
            venueModel = await _mediator.Send(new CreateVenueCommand { VenueCreateRequest = request });
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
    public async Task<ActionResult<VenueResponse>> UpdateVenue(string venueId, VenueUpdateRequest request)
    {
        try
        {
            var venueModel = VenueMapper.VenueUpdateToModel(request);
            venueModel = await _mediator.Send(new UpdateVenueCommand { VenueUpdateRequest = request });
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
    public async Task<ActionResult<string>> DeleteVenue(string venueId)
    {
        try
        {
            await _mediator.Send(new DeleteVenueCommand { VenueId = new Guid(venueId) });

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
