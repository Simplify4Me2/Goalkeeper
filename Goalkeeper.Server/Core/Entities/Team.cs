using System.ComponentModel.DataAnnotations;

namespace Goalkeeper.Server.Core.Entities;

public class Team
{
    [Required]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public string Flag { get; set; } = string.Empty;
}
