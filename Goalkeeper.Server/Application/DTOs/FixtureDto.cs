using System.ComponentModel.DataAnnotations;

namespace Goalkeeper.Server.Application.DTOs;

public class FixtureDto
{
    public int Id { get; set; }

    public string HomeTeamName { get; set; } = string.Empty;

    public string AwayTeamName { get; set; } = string.Empty;

    public uint HomeScore { get; set; }

    public uint AwayScore { get; set; }
}
