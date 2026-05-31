namespace Goalkeeper.Server.Core.Models;

public class TeamStanding
{
    public int Id { get; set; }
    public string GroupName { get; set; } = string.Empty;
    public int TeamId { get; set; }
    public string TeamName { get; set; } = string.Empty;
    public string TeamFlag { get; set; } = string.Empty;
    public int Played { get; set; }
    public int Won { get; set; }
    public int Drawn { get; set; }
    public int Lost { get; set; }
    public int GoalsFor { get; set; }
    public int GoalsAgainst { get; set; }
    public int Points { get; set; }

    // Nullable stubs — populated later when match statistics are tracked
    public int? Possession { get; set; }
    public int? Defense { get; set; }
    public int? Attack { get; set; }
    public int? Passing { get; set; }
    public int? Pressing { get; set; }
}
