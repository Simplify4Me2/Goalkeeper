namespace GoalKeeper.Stats.Application.IO.DTOs
{
    public class TeamRankingDTO
    {
        public long TeamId { get; set; }

        public string TeamName { get; set; }

        public int Points { get; set; }

        public int GamesPlayed { get; set; }
    }
}
