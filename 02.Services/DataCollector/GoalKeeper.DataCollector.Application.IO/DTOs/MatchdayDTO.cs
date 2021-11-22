namespace GoalKeeper.DataCollector.Application.IO.DTOs
{
    public class MatchdayDTO
    {
        public int Matchday { get; set; }

        public MatchDTO[] Matches { get; set; }
    }
}
