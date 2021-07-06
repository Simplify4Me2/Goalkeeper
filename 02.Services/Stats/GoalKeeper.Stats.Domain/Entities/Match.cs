using System;

namespace GoalKeeper.Stats.Domain.Entities
{
    public class Match
    {
        public long Id { get; }

        public Team HomeTeam { get; }

        public int HomeTeamScore { get; }

        public Team AwayTeam { get; }

        public int AwayTeamScore { get; }

        public int Matchday { get; }

        public DateTime Date { get; }

        public Match(long id, Team homeTeam, int homeTeamScore, Team awayTeam, int awayTeamScore, DateTime date, int matchday)
        {
            Id = id;
            HomeTeam = homeTeam;
            HomeTeamScore = homeTeamScore;
            AwayTeam = awayTeam;
            AwayTeamScore = awayTeamScore;
            Date = date;
            Matchday = matchday;
        }
    }
}
