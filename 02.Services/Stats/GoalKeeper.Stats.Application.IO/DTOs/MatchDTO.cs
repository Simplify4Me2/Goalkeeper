using System;

namespace GoalKeeper.Stats.Application.IO.DTOs
{
    public class MatchDTO
    {
        public long Id { get; set; }

        public string HomeTeamName { get; set; }

        public int HomeTeamScore { get; set; }

        public string AwayTeamName { get; set; }

        public int AwayTeamScore { get; set; }

        public int Matchday { get; set; }

        public DateTime Date { get; set; }
    }
}
