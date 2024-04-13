﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Events.Commands;
using SportEvents.Application.Exceptions;
using SportEvents.Application.Models.DTOs;
using SportEvents.Infrastructure.Persistence.Mappers;

namespace SportEvents.Presentation.Http.Controllers;
[ApiController]
[Route("/api/v1/events")]
public class EventController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    // [HttpGet("{eventId}")]
    // public IActionResult GetEventById(string eventId)
    // {
    //    try
    //    {
    //        var @event = _eventService.GetEventById(new Guid(eventId));
    //        var eventReponse = EventMapper.ModelToReponse(@event);

    // return Ok(eventReponse);
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
    [HttpPost]
    public async Task<IActionResult> CreateEvent(EventCreateRequest request)
    {
        try
        {
            var eventModel = EventMapper.EventCreateToModel(request);

            eventModel = await _mediator.Send(new CreateEventCommand { EventCreateRequest = request });
            var eventResponse = EventMapper.ModelToReponse(eventModel);

            return Ok(eventResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { errors = new List<string> { ex.Message } });
        }
    }

    [HttpPatch("{eventId}")]
    public async Task<IActionResult> UpdateEvent(string eventId, EventUpdateRequest request)
    {
        try
        {
            var eventModel = EventMapper.EventUpdateToModel(request);

            eventModel = await _mediator.Send(new UpdateEventCommand { EventId = new Guid(eventId), EventUpdateRequest = request });
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
    public async Task<IActionResult> DeleteEvent(string eventId)
    {
        try
        {
            await _mediator.Send(new DeleteEventCommand { EventId = new Guid(eventId) });
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
