using System;

namespace GoalKeeper.Stats.Domain.ValueObjects
{
    public class Goal
    {
        public Player Player { get; }

        public DateTime Time { get; }

        public Goal(Player player, DateTime time)
        {
            Player = player;
            Time = time;
        }
    }
}
