using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;
using proyectoef.Services;

namespace proyectoef.Controllers;

[Route("api/[controller]")]

public class CategoryController: ControllerBase
{
    ICategoryService categoryService;

    public CategoryController(ICategoryService service)
    {
        categoryService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoryService.Get());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(categoryService.GetById(id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] Category category)
    {
        categoryService.Save(category);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Category category)
    {
        categoryService.Update(id, category);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoryService.Delete(id);
        return Ok();
    }
}

