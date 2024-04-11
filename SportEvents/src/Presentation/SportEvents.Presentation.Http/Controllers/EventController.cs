using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public IActionResult GetEvents()
    {
        try
        {
            var events = _eventService.GetEvents();
            var eventResponses = events.Select(e => EventMapper.ModelToReponse(e)).ToArray();

            return Ok(eventResponses);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpGet("sport/{sportId}")]
    public IActionResult GetEventsBySportId(string sportId)
    {
        try
        {
            var events = _eventService.GetEventsBySportId(new Guid(sportId));
            var eventResponses = events.Select(e => EventMapper.ModelToReponse(e)).ToArray();

            return Ok(eventResponses);
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

    [HttpGet("time")]
    public IActionResult GetEventsInTimeRange([FromQuery] DateTime startTime, [FromQuery] DateTime endTime)
    {
        try
        {
            var events = _eventService.GetEventsInTimeRange(startTime, endTime);
            var eventResponses = events.Select(e => EventMapper.ModelToReponse(e)).ToArray();

            return Ok(eventResponses);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpGet("sport/{sportId}/time")]
    public IActionResult GetEventsBySportInTimeRange(string sportId, [FromQuery] DateTime startTime, [FromQuery] DateTime endTime)
    {
        try
        {
            var events = _eventService.GetEventsBySportInTimeRange(new Guid(sportId), startTime, endTime);
            var eventResponses = events.Select(e => EventMapper.ModelToReponse(e)).ToArray();

            return Ok(eventResponses);
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

    [HttpGet("organizer/{organizerId}")]
    public IActionResult GetEventsByOrganizerId(string organizerId)
    {
        try
        {
            var events = _eventService.GetEventsByOrganizerId(new Guid(organizerId));
            var eventResponses = events.Select(e => EventMapper.ModelToReponse(e)).ToArray();

            return Ok(events);
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
            return NotFound(new { errors = new List<string> { ex.Message } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
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
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
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
        catch (NotFoundException ex)
        {
            return NotFound(new { errors = new List<string> { ex.Message } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpDelete("{eventId}")]
    public IActionResult DeleteEvent(string eventId)
    {
        try
        {
            _eventService.DeleteEvent(new Guid(eventId));
            return Ok(eventId);
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
