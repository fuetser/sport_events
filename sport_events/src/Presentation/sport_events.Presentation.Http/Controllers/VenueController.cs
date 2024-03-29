using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;
using System;
using System.Collections.Generic;

namespace SportEvents.Presentation.Http.Controllers
{
    [ApiController]
    [Route("/api/v1/venues")]
    public class VenueController : ControllerBase
    {
        private readonly IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

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
                if (success)
                {
                    return Created($"/api/v1/venues/{request.Id}", new VenueResponse { Id = request.Id, Name = request.Name });
                }
                return BadRequest(new { errors = new List<string> { "Failed to create venue." } });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }

        [HttpPatch("{venueId}")]
        public IActionResult UpdateVenue(int venueId, VenueUpdateRequest request)
        {
            try
            {
                request.Id = venueId;
                var success = _venueService.UpdateVenue(request);
                if (success)
                {
                    return Ok(new VenueResponse { Id = venueId, Name = request.Name });
                }
                return BadRequest(new { errors = new List<string> { "Failed to update venue." } });
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
                if (success)
                {
                    return Ok(new { message = "Место проведения удалено" });
                }
                return BadRequest(new { errors = new List<string> { "Failed to delete venue." } });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }
    }
}
