namespace GoalKeeper.DataCollector.App.Data
{
    public class MatchService
    {
        public Task<Match[]> GetMatches(int matchday)
        {
            return Task.FromResult(FakeMatches);
        }

        private static Match[] FakeMatches = new Match[]
        {
            new Match { Date = new DateTime(), HomeTeamName= "FC De Kampioenen", HomeTeamScore = 1, AwayTeamName = "KFC Herent", AwayTeamScore = 0 }
        };
    }
}
