namespace Goalkeeper.Server.Application.DTOs;

public class TeamStandingDto
{
    public string Group { get; set; } = string.Empty;
    public string Team { get; set; } = string.Empty;
    public string Flag { get; set; } = string.Empty;
    public int Played { get; set; }
    public int Won { get; set; }
    public int Drawn { get; set; }
    public int Lost { get; set; }
    public int Gf { get; set; }
    public int Ga { get; set; }
    public int Points { get; set; }
    public int? Possession { get; set; }
    public int? Defense { get; set; }
    public int? Attack { get; set; }
    public int? Passing { get; set; }
    public int? Pressing { get; set; }
}
