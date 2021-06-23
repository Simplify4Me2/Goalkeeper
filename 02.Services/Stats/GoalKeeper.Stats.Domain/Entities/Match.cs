using System;

namespace GoalKeeper.Stats.Domain.Entities
{
    public class Match
    {
        public long Id { get; set; }

        public Team HomeTeam { get; set; }

        public int HomeTeamScore { get; set; }

        public Team AwayTeam { get; set; }

        public int AwayTeamScore { get; set; }

        public int Matchday { get; set; }

        public DateTime Date { get; set; }
    }
}
