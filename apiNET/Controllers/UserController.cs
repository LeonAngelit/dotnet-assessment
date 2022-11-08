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


    [HttpGet("{email}")]
    public IActionResult getByEmail(String email)
    {
        return Ok(userService.FindByEmail(email));
    }
    [HttpPost]
    public IActionResult Post([FromBody] User user)

    {
        userService.Save(user);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] User user)
    {
        userService.Update(id, user);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        userService.Delete(id);
        return Ok();
    }
}
