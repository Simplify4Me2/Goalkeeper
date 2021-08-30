﻿namespace GoalKeeper.Stats.Domain.ValueObjects
{
    public class TeamRanking
    {
        public Team Team { get; }

        public int Points { get; }

        public TeamRanking(Team team, int points)
        {
            Team = team;
            Points = points;
        }
    }
}