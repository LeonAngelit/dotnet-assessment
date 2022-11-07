using Microsoft.AspNetCore.Mvc;

namespace apiNET.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    private readonly ILogger<HelloWorldController> _logger;
    IHelloWorldService helloWorldService;

    TareasContext dbContext;

    public HelloWorldController(
        IHelloWorldService helloWorld,
        ILogger<HelloWorldController> logger,
        TareasContext context
    )
    {
        _logger = logger;
        helloWorldService = helloWorld;
        dbContext = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogDebug("Retornando Hello world");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDataBase()
    {
        dbContext.Database.EnsureCreated();
        return Ok();
    }
}
