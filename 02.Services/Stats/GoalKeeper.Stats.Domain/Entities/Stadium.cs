﻿namespace GoalKeeper.Stats.Domain
{
    public class Stadium
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public Stadium(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
