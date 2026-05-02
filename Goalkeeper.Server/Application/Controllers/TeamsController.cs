using Goalkeeper.Server.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Goalkeeper.Server.Application.Controllers;

[ApiController]
[Route("api/teams")]
[Produces("application/json")]
public class TeamsController(ITeamsRepository teamsRepository, ILogger<TeamsController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var teams = await teamsRepository.Get(cancellationToken);

        logger.LogDebug("GET /api/teams returned {Count} teams", teams.Count());

        return Ok(teams.Select(t => new TeamDto { Id = t.Id, Name = t.Name }));
    }
}
