using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;
using System;
using System.Collections.Generic;

namespace SportEvents.Presentation.Http.Controllers
{
    [ApiController]
    [Route("/api/v1/events")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            try
            {
                var events = _eventService.GetEvents();
                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }

        [HttpGet("sport/{sportId}")]
        public IActionResult GetEventsBySportId(int sportId)
        {
            try
            {
                var events = _eventService.GetEventsBySportId(sportId);
                return Ok(events);
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
                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }

        [HttpGet("sport/{sportId}/time")]
        public IActionResult GetEventsBySportInTimeRange(int sportId, [FromQuery] DateTime startTime, [FromQuery] DateTime endTime)
        {
            try
            {
                var events = _eventService.GetEventsBySportInTimeRange(sportId, startTime, endTime);
                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }

        [HttpGet("organizer/{organizerId}")]
        public IActionResult GetEventsByOrganizerId(int organizerId)
        {
            try
            {
                var events = _eventService.GetEventsByOrganizerId(organizerId);
                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }

        [HttpGet("{eventId}")]
        public IActionResult GetEventById(int eventId)
        {
            try
            {
                var @event = _eventService.GetEventById(eventId);
                if (@event != null)
                {
                    return Ok(@event);
                }
                return NotFound(new { errors = new List<string> { "Event not found." } });
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
                var success = _eventService.CreateEvent(request);
                if (success)
                {
                    return Created($"/api/v1/events/{request.Id}", new { id = request.Id, title = request.Title });
                }
                return BadRequest(new { errors = new List<string> { "Failed to create event." } });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }

        [HttpPatch("{eventId}")]
        public IActionResult UpdateEvent(int eventId, EventUpdateRequest request)
        {
            try
            {
                request.Id = eventId;
                var success = _eventService.UpdateEvent(request);
                if (success)
                {
                    return Ok(new { id = eventId, title = request.Title });
                }
                return BadRequest(new { errors = new List<string> { "Failed to update event." } });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }

        [HttpDelete("{eventId}")]
        public IActionResult DeleteEvent(int eventId)
        {
            try
            {
                var success = _eventService.DeleteEvent(eventId);
                if (success)
                {
                    return Ok(new { message = "Event deleted" });
                }
                return BadRequest(new { errors = new List<string> { "Failed to delete event." } });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }
    }
}
