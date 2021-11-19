namespace GoalKeeper.DataCollector.App.Data
{
    public class Match
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string? DBHomeTeamName { get; set; }
        public string? CollectorHomeTeamName { get; set; }

        public int DBHomeTeamScore { get; set; }
        public int CollectorHomeTeamScore { get; set; }

        public string? DBAwayTeamName { get; set; }
        public string? CollectorAwayTeamName { get; set; }

        public int DBAwayTeamScore { get; set; }
        public int CollectorAwayTeamScore { get; set; }
    }
}
