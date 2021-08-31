using GoalKeeper.Stats.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Infrastructure.DataModels
{
    public class MatchDataModel
    {
        public long Id { get; set; }

        public TeamDataModel HomeTeam { get; set; }

        public int HomeTeamScore { get; set; }

        public TeamDataModel AwayTeam { get; set; }

        public int AwayTeamScore { get; set; }

        public int Matchday { get; set; }

        public DateTime Date { get; set; }

        public static PlayedMatch MapOut(MatchDataModel match)
        => new PlayedMatch(match.Id, TeamDataModel.MapOut(match.HomeTeam), TeamDataModel.MapOut(match.AwayTeam), new Score(match.HomeTeamScore, match.AwayTeamScore), match.Date, match.Matchday);

        public static IEnumerable<PlayedMatch> MapOut(IEnumerable<MatchDataModel> matches)
        => matches.Select(match => MapOut(match));
    }
}
