using Goalkeeper.Server.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Goalkeeper.Server.Application;

[ApiController]
[Route("api/fixtures")]
[Produces("application/json")]
public class FixturesController : ControllerBase
{
    private readonly ILogger<FixturesController> _logger;

    public FixturesController(ILogger<FixturesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        List<FixtureDto> fixtures = new List<FixtureDto>();

        _logger.LogDebug("GET endpoint called for fixtures");

        return Ok(fixtures);
    }
}
