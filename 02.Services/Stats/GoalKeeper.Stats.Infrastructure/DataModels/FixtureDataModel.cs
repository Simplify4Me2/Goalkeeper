using GoalKeeper.Stats.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoalKeeper.Stats.Infrastructure.DataModels
{
    public class FixtureDataModel
    {
        public long Id { get; set; }

        public TeamDataModel HomeTeam { get; set; }

        public int HomeTeamScore { get; set; }

        public TeamDataModel AwayTeam { get; set; }

        public int AwayTeamScore { get; set; }

        public int Matchday { get; set; }

        public DateTime Date { get; set; }

        public static Fixture MapOut(FixtureDataModel match)
        => new Fixture(match.Id, TeamDataModel.MapOut(match.HomeTeam), TeamDataModel.MapOut(match.AwayTeam), match.Date, match.Matchday);

        public static IEnumerable<Fixture> MapOut(IEnumerable<FixtureDataModel> matches)
        => matches.Select(match => MapOut(match));
    }
}
