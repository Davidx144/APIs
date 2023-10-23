using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;
using proyectoef.Services;
using System;

namespace proyectoef.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService service)
        {
            productsService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = productsService.Get();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting products: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var product = productsService.GetById(id);
                if (product == null)
                {
                    return NotFound($"Product with ID not found.");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting product with ID {id}: {ex.Message}");
            }
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult GetByCategoryId(Guid categoryId)
        {
            try
            {
                var products = productsService.GetByCategoryId(categoryId);
                if (products == null || !products.Any())
                {
                    return NotFound($"No products found for category with ID");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting products for category with ID {categoryId}: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Products product)
        {
            if (product.CategoryId == Guid.Empty || string.IsNullOrEmpty(product.Name) || string.IsNullOrEmpty(product.Descripcion))
            {
                return BadRequest("Category ID, name, and description are required.");
            }

            try
            {
                productsService.Save(product);
                return Ok("Product created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating product: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Products product)

        {
            var existingProduct = productsService.GetById(id);
            if (existingProduct == null)
            {
                return NotFound($"Product with ID not found.");
            }

            if (product.CategoryId == Guid.Empty && string.IsNullOrEmpty(product.Name) && string.IsNullOrEmpty(product.Descripcion))
            {
                return BadRequest("Category ID, name, and description are required.");
            }

            try
            {
                productsService.Update(id, product);
                return Ok("Product updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating product with ID {id}: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existingProduct = productsService.GetById(id);
            if (existingProduct == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            try
            {
                productsService.Delete(id);
                return Ok("Product deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting product with ID {id}: {ex.Message}");
            }
        }
    }
}