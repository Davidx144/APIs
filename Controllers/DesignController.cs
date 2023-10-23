using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;
using proyectoef.Services;
using System;

namespace proyectoef.Controllers
{
    [Route("api/[controller]")]
    public class DesignController : ControllerBase
    {
        private readonly IDesignService designService;

        public DesignController(IDesignService service)
        {
            designService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var designs = designService.Get();
                return Ok(designs);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error getting designs: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var design = designService.GetById(id);
                if (design == null)
                {
                    return NotFound($"Design with ID {id} not found.");
                }
                return Ok(design);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error getting design with ID {id}: {ex.Message}");
            }
        }

        [HttpGet("product/{productId}")]
        public IActionResult GetByProductId(Guid productId)
        {
            try
            {
                var designs = designService.GetByProductId(productId);
                if (designs == null || !designs.Any())
                {
                    return NotFound($"No designs found for product");
                }
                return Ok(designs);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error getting designs for product with ID {productId}: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Design design)
        {
            if (design == null || design.ProductId == Guid.Empty || string.IsNullOrEmpty(design.Name) || string.IsNullOrEmpty(design.Descripcion))
            {
                return BadRequest("Product ID, name, and description are required.");
            }

            try
            {
                designService.Save(design);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating design: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Design design)
        {
            var existingDesign = designService.GetById(id);
            if (existingDesign == null)
            {
                return NotFound($"Design with ID {id} not found.");
            }

            if (design.ProductId == Guid.Empty && string.IsNullOrEmpty(design.Name) && string.IsNullOrEmpty(design.Descripcion))
            {
                return BadRequest("Design is required.");
            }

            try
            {
                designService.Update(id, design);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating design with ID {id}: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existingDesign = designService.GetById(id);
            if (existingDesign == null)
            {
                return NotFound($"Design with ID {id} not found.");
            }

            try
            {
                designService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting design with ID {id}: {ex.Message}");
            }
        }
    }
}