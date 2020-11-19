using GoalKeeper.MApi.Application.IO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoalKeeper.MApi.Application.Mappers
{
    public static class FixtureMapper
    {
        public static FixtureDTO MapOut(this Domain.Models.Fixture fixture)
        {
            return new FixtureDTO
            {
                HomeTeam = fixture.HomeTeam,
                HomeScore = fixture.HomeScore,
                AwayTeam = fixture.AwayTeam,
                AwayScore = fixture.HomeScore
            };
        }

        public static List<FixtureDTO> MapOut(this List<Domain.Models.Fixture> fixtures)
            => fixtures.Select(MapOut).ToList();
    }
}
