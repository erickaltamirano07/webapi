using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWordController: ControllerBase
{
    IHelloWorldService helloWorldService;
    private readonly ILogger<HelloWordController> _logger;

    public HelloWordController(IHelloWorldService helloWorldService,ILogger<HelloWordController> logger)
    {
        _logger=logger;
        this.helloWorldService= helloWorldService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogDebug("Mensaje de Hello World");
        return Ok(helloWorldService.GetHelloWorld());
    }
}
