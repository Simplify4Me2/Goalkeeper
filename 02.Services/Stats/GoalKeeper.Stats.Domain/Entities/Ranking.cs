using GoalKeeper.Stats.Domain.Core;
using System.Collections.Generic;

namespace GoalKeeper.Stats.Domain.Entities
{
    public class Ranking : Aggregate //: AggregateBase
    {
        //public long Id { get; set; }

        public string Name { get; set; }

        public List<TeamRanking> TeamRankings { get; set; }

        //private Ranking() { }

        //public Ranking(IEnumerable<IDomainEvent> events) : base(events)
        //{

        //}
    }
}
