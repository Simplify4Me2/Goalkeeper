using System.Collections.Generic;

namespace GoalKeeper.Stats.Domain.Entities
{
    public class Team
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();

        public Stadium Stadium { get; set; }

        // Should I move the logic over here?
        public int RankingPoints()
        {
            //this.Matches.Select(match => won / loss);
            return 5;
        }
    }
}
