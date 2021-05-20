using GoalKeeper.Stats.Domain.Core;
using System.Collections.Generic;

namespace GoalKeeper.Stats.Domain.Entities
{
    public class Ranking //: Aggregate
    {
        //public long Id { get; set; }

        public string Name { get; set; }

        //public List<Team> Teams { get; set; }

        public List<TeamRanking> TeamRankings { get; set; }
    }
}
