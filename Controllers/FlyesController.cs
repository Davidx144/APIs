using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;
using proyectoef.Services;
using System;

namespace proyectoef.Controllers
{
    [Route("api/[controller]")]
    public class FlyesController : ControllerBase
    {
        private readonly IFlyesService flyesService;

        public FlyesController(IFlyesService service)
        {
            flyesService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var flyes = flyesService.Get();
                return Ok(flyes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting flyes: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var flyes = flyesService.GetById(id);
                if (flyes == null)
                {
                    return NotFound($"Flyes with ID not found.");
                }
                return Ok(flyes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting flyes with ID {id}: {ex.Message}");
            }
        }

        [HttpGet("design/{designId}")]
        public IActionResult GetByDesignId(Guid designId)
        {
            try
            {
                var flyes = flyesService.GetByDesignId(designId);
                if (flyes == null || !flyes.Any())
                {
                    return NotFound($"No flyes found for design with ID");
                }
                return Ok(flyes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting flyes for design with ID {designId}: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Flyes flyes)
        {
            if (flyes.DesignId == Guid.Empty || string.IsNullOrEmpty(flyes.Name) || string.IsNullOrEmpty(flyes.Descripcion))
            {
                return BadRequest("Design ID, name, and description are required.");
            }

            try
            {
                flyesService.Save(flyes);
                return Ok("Flyes created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating flyes: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Flyes flyes)
        {
            var existingFlyes = flyesService.GetById(id);
            if (existingFlyes == null)
            {
                return NotFound($"Flyes with ID not found.");
            }

            if (flyes.DesignId == Guid.Empty && string.IsNullOrEmpty(flyes.Name) && string.IsNullOrEmpty(flyes.Descripcion))
            {
                return BadRequest("Design ID, name, and description are required.");
            }

            try
            {
                flyesService.Update(id, flyes);
                return Ok("Flyes updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating flyes with ID {id}: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existingFlyes = flyesService.GetById(id);
            if (existingFlyes == null)
            {
                return NotFound($"Flyes with ID not found.");
            }

            try
            {
                flyesService.Delete(id);
                return Ok("Flyes deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting flyes with ID {id}: {ex.Message}");
            }
        }
    }
}