using GoalKeeper.Stats.Domain.Core;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Domain.Entities
{
    public class Ranking //: Aggregate
    {
        //public long Id { get; set; }

        public string Name { get; set; }

        //public List<Team> Teams { get; set; }

        public List<TeamRanking> TeamRankings { get; set; }

        public List<Team> Teams { get; set; }

        public List<Match> Matches { get; set; }

        public static TeamRanking CalculatePoints(Team team, List<Match> matches)
        {
            int points = 0;
            var homeMatches = matches.Where(match => match.HomeTeam.Id == team.Id);
            foreach (var match in homeMatches)
            {
                if (match.HomeTeamScore > match.AwayTeamScore) points += 3;
                if (match.HomeTeamScore == match.AwayTeamScore) points += 1;
            };

            var awayMatches = matches.Where(match => match.AwayTeam.Id == team.Id);
            foreach (var match in homeMatches)
            {
                if (match.HomeTeamScore > match.AwayTeamScore) points += 3;
                if (match.HomeTeamScore == match.AwayTeamScore) points += 1;
            };

            return new TeamRanking
            {
                Team = team,
                Points = points
            };
        }
    }
}
