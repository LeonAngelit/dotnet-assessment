using Microsoft.AspNetCore.Mvc;
using apiNET.Models;
using apiNET.Services;

namespace apiNET.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareasController : ControllerBase
{
    ITareaService tareaService;

    public TareasController(ITareaService service)
    {
        tareaService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        return Ok(tareaService.Save(tarea));
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] Tarea tarea)
    {
        return Ok(tareaService.Update(id, tarea));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        return Ok(tareaService.Delete(id));
    }
}
