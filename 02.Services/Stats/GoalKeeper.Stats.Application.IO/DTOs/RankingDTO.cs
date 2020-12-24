using System.Collections.Generic;

namespace GoalKeeper.Stats.Application.IO.DTOs
{
    public class RankingDTO
    {
        public long Id { get; set; }

        public string CompetitionName { get; set; }

        public List<string> Teams { get; set; }
    }
}
