using Microsoft.AspNetCore.Mvc;
using apiNET.Models;
using apiNET.Services;

namespace apiNET.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    ICategoriaService categoriaService;

    public CategoriasController(ICategoriaService service)
    {
        categoriaService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoriaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        return Ok(categoriaService.Save(categoria));
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] Categoria categoria)
    {
        return Ok(categoriaService.Update(id, categoria));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        return Ok(categoriaService.Delete(id));
    }
}
