using System;

namespace GoalKeeper.DataCollector.Application.IO.DTOs
{
    public class MatchDTO
    {
        public DateTime Date { get; set; }

        public string HomeTeamName { get; set; }

        public int? HomeTeamScore { get; set; }

        public string AwayTeamName { get; set; }

        public int? AwayTeamScore { get; set; }
    }
}
