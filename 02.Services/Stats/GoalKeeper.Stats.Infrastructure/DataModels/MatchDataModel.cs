using GoalKeeper.Stats.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Infrastructure.DataModels
{
    public class MatchDataModel
    {
        public long Id { get; set; }

        public TeamDataModel HomeTeam { get; set; }

        public int? HomeTeamScore { get; set; }

        public TeamDataModel AwayTeam { get; set; }

        public int? AwayTeamScore { get; set; }

        public int Matchday { get; set; }

        public DateTime Date { get; set; }

        public static Match MapOut(MatchDataModel match)
        {
            Score score = null;
            if (match.HomeTeamScore != null && match.AwayTeamScore != null)
                score = new Score(match.HomeTeamScore.Value, match.AwayTeamScore.Value);
            return new Match(match.Id, TeamDataModel.MapOut(match.HomeTeam), TeamDataModel.MapOut(match.AwayTeam), score, match.Date, match.Matchday);
        }

        public static IEnumerable<Match> MapOut(IEnumerable<MatchDataModel> matches)
        => matches.Select(match => MapOut(match));
    }
}
