using System.Collections.Generic;

namespace GoalKeeper.Stats.Domain
{
    public class Team
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public List<Player> Players { get; private set; } = new List<Player>();

        public Stadium Stadium { get; set; }

        public Team(long id, string name, Stadium stadium, List<Player> players)
        {
            Id = id;
            Name = name;
            Stadium = stadium;
            Players = players;
        }

        public string[] FormToString(List<Match> matches)
        {
            return new[] { "W", "D", "W", "L" };
        }
    }
}
