using System.ComponentModel.DataAnnotations;

namespace Goalkeeper.Server.Core;

public class Team
{
    [Required]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }
}
