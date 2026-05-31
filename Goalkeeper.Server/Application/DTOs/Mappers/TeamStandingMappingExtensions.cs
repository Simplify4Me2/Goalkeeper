using Goalkeeper.Server.Core.Models;

namespace Goalkeeper.Server.Application.DTOs.Mappers;

public static class TeamStandingMappingExtensions
{
    public static TeamStandingDto ToDto(this TeamStanding fixture)
    {
        return new TeamStandingDto
        {
            Group = fixture.GroupName,
            Team = fixture.TeamName,
            Flag = fixture.TeamFlag,
            Played = fixture.Played,
            Won = fixture.Won,
            Drawn = fixture.Drawn,
            Lost = fixture.Lost,
            Gf = fixture.GoalsFor,
            Ga = fixture.GoalsAgainst,
            Points = fixture.Points,
            Possession = fixture.Possession,
            Defense = fixture.Defense,
            Attack = fixture.Attack,
            Passing = fixture.Passing,
            Pressing = fixture.Pressing
        };
    }
}
