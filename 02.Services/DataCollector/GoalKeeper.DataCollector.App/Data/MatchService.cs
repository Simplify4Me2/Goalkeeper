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
            new Match { Date = new DateTime(), DBHomeTeamName= "RSC Anderlecht", DBHomeTeamScore = 1, DBAwayTeamName = "KV Kortrijk", DBAwayTeamScore = 0, CollectorHomeTeamName= "RSC Anderlecht", CollectorHomeTeamScore = 1, CollectorAwayTeamName = "KV Kortrijk", CollectorAwayTeamScore = 0 },
            new Match { Date = new DateTime(), DBHomeTeamName= "Royal Antwerp FC", DBHomeTeamScore = 1, DBAwayTeamName = "Oud-Heverlee Leuven", DBAwayTeamScore = 0, CollectorHomeTeamName= "RSC Anderlecht", CollectorHomeTeamScore = 1, CollectorAwayTeamName = "KV Kortrijk", CollectorAwayTeamScore = 0 },
            new Match { Date = new DateTime(), DBHomeTeamName= "Beerschot VA", DBHomeTeamScore = 1, DBAwayTeamName = "KV Oostende", DBAwayTeamScore = 0, CollectorHomeTeamName= "RSC Anderlecht", CollectorHomeTeamScore = 1, CollectorAwayTeamName = "KV Kortrijk", CollectorAwayTeamScore = 0 },
            new Match { Date = new DateTime(), DBHomeTeamName= "Cercle Brugge", DBHomeTeamScore = 1, DBAwayTeamName = "RFC Seraing", DBAwayTeamScore = 0, CollectorHomeTeamName= "RSC Anderlecht", CollectorHomeTeamScore = 1, CollectorAwayTeamName = "KV Kortrijk", CollectorAwayTeamScore = 0 },
            new Match { Date = new DateTime(), DBHomeTeamName= "Club Brugge", DBHomeTeamScore = 1, DBAwayTeamName = "Standard Luik", DBAwayTeamScore = 0, CollectorHomeTeamName= "RSC Anderlecht", CollectorHomeTeamScore = 1, CollectorAwayTeamName = "KV Kortrijk", CollectorAwayTeamScore = 0 },
            new Match { Date = new DateTime(), DBHomeTeamName= "Royal Charleroi Sporting Club", DBHomeTeamScore = 1, DBAwayTeamName = "Sint-Truidense VV", DBAwayTeamScore = 0, CollectorHomeTeamName= "RSC Anderlecht", CollectorHomeTeamScore = 1, CollectorAwayTeamName = "KV Kortrijk", CollectorAwayTeamScore = 0 },
            new Match { Date = new DateTime(), DBHomeTeamName= "KAS Eupen", DBHomeTeamScore = 1, DBAwayTeamName = "Zulte Waregem", DBAwayTeamScore = 0, CollectorHomeTeamName= "RSC Anderlecht", CollectorHomeTeamScore = 1, CollectorAwayTeamName = "KV Kortrijk", CollectorAwayTeamScore = 0 },
            new Match { Date = new DateTime(), DBHomeTeamName= "KRC Genk", DBHomeTeamScore = 1, DBAwayTeamName = "Union", DBAwayTeamScore = 0, CollectorHomeTeamName= "RSC Anderlecht", CollectorHomeTeamScore = 1, CollectorAwayTeamName = "KV Kortrijk", CollectorAwayTeamScore = 0 },
            new Match { Date = new DateTime(), DBHomeTeamName= "KAA Gent", DBHomeTeamScore = 1, DBAwayTeamName = "KV Mechelen", DBAwayTeamScore = 0, CollectorHomeTeamName= "RSC Anderlecht", CollectorHomeTeamScore = 1, CollectorAwayTeamName = "KV Kortrijk", CollectorAwayTeamScore = 0 },
        };
    }
}
