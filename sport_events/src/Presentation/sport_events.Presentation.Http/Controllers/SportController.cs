using Microsoft.AspNetCore.Mvc;
using SportEvents.Application.Contracts;
using SportEvents.Application.Models.Requests;
using SportEvents.Application.Models.Responses;
using System;
using System.Collections.Generic;

namespace SportEvents.Presentation.Http.Controllers
{
    [ApiController]
    [Route("/api/v1/sports")]
    public class SportController : ControllerBase
    {
        private readonly ISportService _sportService;

        public SportController(ISportService sportService)
        {
            _sportService = sportService;
        }

        [HttpGet]
        public IActionResult GetSports()
        {
            try
            {
                var sports = _sportService.GetSports();
                return Ok(sports);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }

        [HttpPost]
        public IActionResult CreateSport([FromBody] SportCreateRequest request)
        {
            try
            {
                var success = _sportService.CreateSport(request);
                if (success)
                {
                    return Created($"/api/v1/sports/{request.Name}", new { id = request.Name, name = request.Name });
                }
                return BadRequest(new { errors = new List<string> { "Failed to create sport." } });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }

        [HttpPatch("{sportId}")]
        public IActionResult UpdateSport(int sportId, [FromBody] SportUpdateRequest request)
        {
            try
            {
                request.Id = sportId;
                var success = _sportService.UpdateSport(request);
                if (success)
                {
                    return Ok(new { id = sportId, name = request.Name });
                }
                return BadRequest(new { errors = new List<string> { "Failed to update sport." } });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }

        [HttpDelete("{sportId}")]
        public IActionResult DeleteSport(int sportId)
        {
            try
            {
                var success = _sportService.DeleteSport(sportId);
                if (success)
                {
                    return Ok(new { message = "Sport deleted" });
                }
                return BadRequest(new { errors = new List<string> { "Failed to delete sport." } });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { errors = new List<string> { ex.Message } });
            }
        }
    }
}
