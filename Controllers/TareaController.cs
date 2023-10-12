using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;
using proyectoef.Services;

namespace proyectoef.Controllers;

[Route("api/[controller]")]

public class TareaController : ControllerBase
{
    //inyectamos la dependencia
    ITareasService tareaService;

    //le pasamos la dependencia al constructor
    public TareaController(ITareasService tarea)
    {
        tareaService = tarea;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        if (tarea == null)
        {
            return BadRequest();
        }

        tareaService.Save(tarea);
        return Ok();
    }
    /* public IActionResult Post([FromBody] Tarea tarea)
    {
        tareaService.Save(tarea);
        return Ok();
    } */

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {
        tareaService.Update(id, tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        tareaService.Delete(id);
        return Ok();
    }
}