using System.Collections.Generic;

namespace GoalKeeper.Stats.Domain.Entities
{
    public class Ranking
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<string> Teams { get; set; }
    }
}
