namespace GoalKeeper.Stats.Domain
{
    public class TeamRanking
    {
        public Team Team { get; }

        public int Points { get; }
        
        public int GamesPlayed { get; }

        public TeamRanking(Team team, int points, int gamesPlayed)
        {
            Team = team;
            Points = points;
            GamesPlayed = gamesPlayed;
        }
    }
}
