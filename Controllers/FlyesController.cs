using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;
using proyectoef.Services;

namespace proyectoef.Controllers;

[Route("api/[controller]")]

public class FlyesController: ControllerBase
{
    IFlyesService flyesService;

    public FlyesController(IFlyesService service)
    {
        flyesService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(flyesService.Get());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(flyesService.GetById(id));
    }

    [HttpGet("design/{designId}")]
    public IActionResult GetByDesignId(Guid designId)
    {
        return Ok(flyesService.GetByDesignId(designId));
    }

    [HttpPost]
    public IActionResult Post([FromBody] Flyes flyes)
    {
        flyesService.Save(flyes);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Flyes flyes)
    {
        flyesService.Update(id, flyes);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        flyesService.Delete(id);
        return Ok();
    }
}