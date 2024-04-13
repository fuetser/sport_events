using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.DTOs;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Presentation.Http.Controllers;
[ApiController]
[Route("/api/v1/organizers")]
public class OrganizerController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateOrganizer(OrganizerCreateRequest request)
    {
        try
        {
            var organizerModel = OrganizerMapper.OrganizerCreateToModel(request);

            organizerModel = await _mediator.Send(new CreateOrganizerCommand { OrganizerCreateRequest = request });
            var organizerResponse = OrganizerMapper.ModelToReponse(organizerModel);

            return Ok(organizerResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    // [HttpGet("{organizerId}")]
    // public IActionResult GetOrganizer(string organizerId)
    // {
    //    try
    //    {
    //        var organizerModel = _organizerService.GetOrganizerById(new Guid(organizerId));
    //        var organizerResponse = OrganizerMapper.ModelToReponse(organizerModel);

    // return Ok(organizerResponse);
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
    [HttpPatch("{organizerId}")]
    public async Task<IActionResult> UpdateOrganizer(string organizerId, OrganizerUpdateRequest request)
    {
        try
        {
            var organizerModel = OrganizerMapper.OrganizerUpdateToModel(request);

            organizerModel = await _mediator.Send(new UpdateOrganizerCommand { OrganizerId = new Guid(organizerId), OrganizerUpdateRequest = request });

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
    public async Task<IActionResult> DeleteOrganizer(string organizerId)
    {
        try
        {
            await _mediator.Send(new DeleteOrganizerCommand { OrganizerId = new Guid(organizerId) });

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
}
