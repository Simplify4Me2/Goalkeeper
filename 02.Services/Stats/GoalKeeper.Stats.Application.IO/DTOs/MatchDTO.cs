using System;

namespace GoalKeeper.Stats.Application.IO.DTOs
{
    public class MatchDTO
    {
        public long Id { get; set; }

        public long HomeTeamId { get; set; }

        public string HomeTeamName { get; set; }

        public string HomeTeamScore { get; set; }

        public long AwayTeamId { get; set; }

        public string AwayTeamName { get; set; }

        public string AwayTeamScore { get; set; }

        public DateTime Date { get; set; }

        public bool IsPlayed { get; set; }
    }
}
