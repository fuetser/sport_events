using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportEvents.Application.Contracts;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.DTOs;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Presentation.Http.Controllers;
[ApiController]
[Route("/api/v1/events")]
public class EventController(IEventService eventService) : ControllerBase
{
    private readonly IEventService _eventService = eventService;

    [HttpGet("{eventId}")]
    public IActionResult GetEventById(string eventId)
    {
        try
        {
            var @event = _eventService.GetEventById(new Guid(eventId));
            var eventReponse = EventMapper.ModelToReponse(@event);

            return Ok(eventReponse);
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
    public IActionResult CreateEvent(EventCreateRequest request)
    {
        try
        {
            var eventModel = EventMapper.EventCreateToModel(request);
            eventModel = _eventService.CreateEvent(eventModel);
            var eventResponse = EventMapper.ModelToReponse(eventModel);

            return Ok(eventResponse);
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

    [HttpPatch("{eventId}")]
    public IActionResult UpdateEvent(string eventId, EventUpdateRequest request)
    {
        try
        {
            var eventModel = EventMapper.EventUpdateToModel(request);
            eventModel = _eventService.UpdateEvent(new Guid(eventId), eventModel);
            var eventResponse = EventMapper.ModelToReponse(eventModel);

            return Ok(eventResponse);
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

    [HttpDelete("{eventId}")]
    public IActionResult DeleteEvent(string eventId)
    {
        try
        {
            _eventService.DeleteEvent(new Guid(eventId));
            return Ok(new { id = eventId });
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
