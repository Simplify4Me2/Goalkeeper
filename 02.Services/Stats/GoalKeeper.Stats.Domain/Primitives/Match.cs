using GoalKeeper.Stats.Domain.ValueObjects;

namespace GoalKeeper.Stats.Domain.Primitives
{
    public abstract class Match
    {
        public Match(long id, Team homeTeam, Team awayTeam, int matchday)
        {
            Id = id;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Matchday = matchday;
        }

        public long Id { get; }

        public Team HomeTeam { get; }

        public Team AwayTeam { get; }

        public int Matchday { get; }
    }
}
