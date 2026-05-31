namespace Goalkeeper.Server.Application.DTOs;

public class GroupStandingsDto
{
    public string GroupName { get; set; } = string.Empty;
    public IEnumerable<TeamStandingDto> Standings { get; set; } = [];
}
