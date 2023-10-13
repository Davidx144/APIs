using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;
using proyectoef.Services;

namespace proyectoef.Controllers;

[Route("api/[controller]")]
public class DesignController: ControllerBase
{
    IDesignService designService;

    public DesignController(IDesignService service)
    {
        designService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(designService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Design design)
    {
        designService.Save(design);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Design design)
    {
        designService.Update(id, design);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        designService.Delete(id);
        return Ok();
    }
}