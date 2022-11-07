using Microsoft.AspNetCore.Mvc;
using apiNET.Models;
using apiNET.Services;

namespace apiNET.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    IUserService userService;

    public UserController(IUserService service)
    {
        userService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(userService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] User user)
    {
        return Ok(userService.Save(user));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] User user)
    {
        return Ok(userService.Update(id, user));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(userService.Delete(id));
    }
}
