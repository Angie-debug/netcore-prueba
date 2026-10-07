using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public SampleController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var mensaje = _configuration["GreetingMessage"] ?? "Hola por defecto";
        return Ok(new { message = mensaje });
    }

    [HttpGet("env")]
    public IActionResult GetEnv()
    {
        // Se puede acceder a `/Sample/env` para ver este resultado
        var configMessage = _configuration["GreetingMessage"] ?? "No se encontró";
        var currentEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        return Ok(new 
        { 
            variable_GreetingMessage = configMessage,
            entorno_actual = currentEnvironment
        });
    }
}
