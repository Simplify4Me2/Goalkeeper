using System;

namespace GoalKeeper.Stats.Domain.ValueObjects
{
    public class Goal
    {
        public Player Player { get; }

        public int Minute { get; }

        public Goal(Player player, int minute)
        {
            Player = player;
            Minute = minute;
        }
    }
}
