using System;

namespace GoalKeeper.Stats.Domain.ValueObjects
{
    public abstract class Match
    {
        public long Id { get; }

        public Team HomeTeam { get; }

        public Team AwayTeam { get; }

        //public Score Score { get; }

        public int Matchday { get; }

        //public DateTime Date { get; }

        //public bool IsPlayed { get; }

        public Match(long id, Team homeTeam, Team awayTeam, int matchday)
        {
            Id = id;
            HomeTeam = homeTeam;
            //Score = score;
            AwayTeam = awayTeam;
            //Date = date;
            Matchday = matchday;
        }
    }
}
