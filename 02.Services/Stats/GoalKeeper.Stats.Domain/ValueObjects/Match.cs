using System;

namespace GoalKeeper.Stats.Domain
{
    public class Match
    {
        public Match(long id, Team homeTeam, Team awayTeam, Score score, DateTime date, int matchday)
        {
            Id = id;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Score = score;
            Date = date;
            Matchday = matchday;
            Status = score == null ? Status.Scheduled : Status.Played;
        }

        public long Id { get; }

        public Team HomeTeam { get; }

        public Team AwayTeam { get; }

        public Score Score { get; }

        public DateTime Date { get; }

        public int Matchday { get; }

        public Status Status { get; }
    }

    public enum Status
    {
        Played = 0,
        Scheduled = 1
    }
}
