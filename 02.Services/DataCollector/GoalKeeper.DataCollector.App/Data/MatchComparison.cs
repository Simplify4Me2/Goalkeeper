namespace GoalKeeper.DataCollector.App.Data
{
    public class MatchComparison
    {
        public int MatchId { get; set; }

        public Match? DatabaseVersion { get; set; }

        public Match? CollectedVersion { get; set; }
    }

    public class Match
    {
        public DateTime Date { get; set; }

        public string? HomeTeamName { get; set; }

        public int HomeTeamScore { get; set; }

        public string? AwayTeamName { get; set; }

        public int AwayTeamScore { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Match match &&
                   Date == match.Date &&
                   HomeTeamName == match.HomeTeamName &&
                   HomeTeamScore == match.HomeTeamScore &&
                   AwayTeamName == match.AwayTeamName &&
                   AwayTeamScore == match.AwayTeamScore;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Date, HomeTeamName, HomeTeamScore, AwayTeamName, AwayTeamScore);
        }
    }
}
