using System.Collections.Generic;

namespace GoalKeeper.Stats.Domain.Entities
{
    public class Team
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public List<Player> Players { get; private set; } = new List<Player>();

        //public Stadium Stadium { get; set; }

        public Team(long id, string name, List<Player> players)
        {
            Id = id;
            Name = name;
            Players = players;
        }

        // Should I move the logic over here?
        public int RankingPoints()
        {
            //this.Matches.Select(match => won / loss);
            return 5;
        }
    }
}
