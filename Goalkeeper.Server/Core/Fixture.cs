using System.ComponentModel.DataAnnotations;

namespace Goalkeeper.Server.Core;

public class Fixture
{
    [Required]
    public int Id { get; set; }

    [Required]
    public required string HomeTeam { get; set; }

    [Required]
    public required string AwayTeam { get; set; }

    public uint HomeScore { get; set; }

    public uint AwayScore { get; set; }
}
