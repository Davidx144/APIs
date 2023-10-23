using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;
using proyectoef.Services;
using System;

namespace proyectoef.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService service)
        {
            categoryService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var categories = categoryService.Get();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error getting categories: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var category = categoryService.GetById(id);
                if (category == null)
                {
                    return NotFound($"Category not found.");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error getting category with ID {id}: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            if (string.IsNullOrEmpty(category.Name) || string.IsNullOrEmpty(category.Descripcion))
            {
                return BadRequest("Category name, descripcion or status are required");
            }

            try
            {
                categoryService.Save(category);
                return Ok($"Category '{category.Name}' created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating category: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Category category)
        {
            var existingCategory = categoryService.GetById(id);
            if (existingCategory == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            if (string.IsNullOrEmpty(category.Name) && string.IsNullOrEmpty(category.Descripcion))
            {
                return BadRequest("Category name and description are required.");
            }

            try
            {
                categoryService.Update(id, category);
                return Ok("Category updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating category with ID {id}: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existingCategory = categoryService.GetById(id);
            if (existingCategory == null)
            {
                return NotFound($"Category not found.");
            }

            try
            {
                categoryService.Delete(id);
                return Ok("Category deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting category with ID {id}: {ex.Message}");
            }
        }
    }
}