using Goalkeeper.Server.Core;

namespace Goalkeeper.Server.Application.DTOs.Mappers;

public static class FixtureMappingExtensions
{
    public static FixtureDto MapOut(this Fixture fixture)
    {
        return new FixtureDto
        {
            HomeTeamName = fixture.HomeTeam,
            HomeScore = fixture.HomeScore,
            AwayTeamName = fixture.AwayTeam,
            AwayScore = fixture.HomeScore
        };
    }

    public static List<FixtureDto> MapOut(this List<Fixture> fixtures)
        => fixtures.Select(MapOut).ToList();
}
