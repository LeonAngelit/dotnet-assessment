using Microsoft.AspNetCore.Mvc;

namespace apiNET.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DbController : ControllerBase
{
    private readonly ILogger<DbController> _logger;


    QuestionaryContext dbContext;

    public DbController(
        ILogger<DbController> logger,
        QuestionaryContext context
    )
    {
        _logger = logger;
        dbContext = context;
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDataBase()
    {
        dbContext.Database.EnsureCreated();
        return Ok();
    }
}
