using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;
using proyectoef.Services;

namespace proyectoef.Controllers;

[Route("api/[controller]")]

public class ProductsController: ControllerBase
{
    IProductsService productsService;

    public ProductsController(IProductsService service)
    {
        productsService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(productsService.Get());
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        return Ok(productsService.GetById(id));
    }

    [HttpGet("category/{categoryId}")]
    public IActionResult GetByCategoryId(Guid categoryId)
    {
        return Ok(productsService.GetByCategoryId(categoryId));
    }

    [HttpPost]
    public IActionResult Post([FromBody] Products products)
    {
        productsService.Save(products);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Products products)
    {
        productsService.Update(id, products);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        productsService.Delete(id);
        return Ok();
    }
}