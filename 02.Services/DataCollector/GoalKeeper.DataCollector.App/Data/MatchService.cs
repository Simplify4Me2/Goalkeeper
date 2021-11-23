namespace GoalKeeper.DataCollector.App.Data
{
    public class MatchService
    {
        public Task<MatchComparison[]> GetMatches(int matchday)
        {
            return Task.FromResult(FakeDBMatches);
        }

        private readonly static MatchComparison[] FakeDBMatches = new MatchComparison[]
        {
            new MatchComparison {
                MatchId = 1,
                DatabaseVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "RSC Anderlecht",
                    HomeTeamScore = 1,
                    AwayTeamName = "KV Kortrijk",
                    AwayTeamScore = 0
                },
                CollectedVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "RSC Anderlecht",
                    HomeTeamScore = 1,
                    AwayTeamName = "KV Kortrijk",
                    AwayTeamScore = 0                                    
                }
            },
            new MatchComparison {
                MatchId = 2,
                DatabaseVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "Royal Antwerp FC",
                    HomeTeamScore = 1,
                    AwayTeamName = "Oud-Heverlee Leuven",
                    AwayTeamScore = 0
                },
                CollectedVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "Royal Antwerp FC",
                    HomeTeamScore = 1,
                    AwayTeamName = "Oud-Heverlee Leuven",
                    AwayTeamScore = 0
                }
            },
            new MatchComparison {
                MatchId = 3,
                DatabaseVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "Beerschot VA",
                    HomeTeamScore = 1,
                    AwayTeamName = "KV Oostende",
                    AwayTeamScore = 0
                },
                CollectedVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "Beerschot VA",
                    HomeTeamScore = 1,
                    AwayTeamName = "KV Oostende",
                    AwayTeamScore = 0
                }
            },
            new MatchComparison {
                MatchId = 4,
                DatabaseVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "Cercle Brugge",
                    HomeTeamScore = 1,
                    AwayTeamName = "RFC Seraing",
                    AwayTeamScore = 0
                },
                CollectedVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "Cercle Brugge",
                    HomeTeamScore = 1,
                    AwayTeamName = "RFC Seraing",
                    AwayTeamScore = 0
                }
            },
            new MatchComparison {
                MatchId = 5,
                DatabaseVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "Club Brugge",
                    HomeTeamScore = 1,
                    AwayTeamName = "Standard Luik",
                    AwayTeamScore = 0
                },
                CollectedVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "Club Brugge",
                    HomeTeamScore = 1,
                    AwayTeamName = "Standard Luik",
                    AwayTeamScore = 0
                }
            },
            new MatchComparison {
                MatchId = 6,
                DatabaseVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "Royal Charleroi Sporting Club",
                    HomeTeamScore = 1,
                    AwayTeamName = "Sint-Truidense VV",
                    AwayTeamScore = 0
                },
                CollectedVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "Royal Charleroi Sporting Club",
                    HomeTeamScore = 1,
                    AwayTeamName = "Sint-Truidense VV",
                    AwayTeamScore = 0
                }
            },
            new MatchComparison {
                MatchId = 7,
                DatabaseVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "KAS Eupen",
                    HomeTeamScore = 1,
                    AwayTeamName = "Zulte Waregem",
                    AwayTeamScore = 0
                },
                CollectedVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "KAS Eupen",
                    HomeTeamScore = 1,
                    AwayTeamName = "Zulte Waregem",
                    AwayTeamScore = 0
                }
            },
            new MatchComparison {
                MatchId = 8,
                DatabaseVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "KRC Genk",
                    HomeTeamScore = 1,
                    AwayTeamName = "Union",
                    AwayTeamScore = 0
                },
                CollectedVersion = new Match
                {
                    Date = DateTime.Now,
                    HomeTeamName = "KRC Genk",
                    HomeTeamScore = 1,
                    AwayTeamName = "Union",
                    AwayTeamScore = 0
                }
            },
            new MatchComparison {
                MatchId = 9,
                DatabaseVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "KAA Gent",
                    HomeTeamScore = 1,
                    AwayTeamName = "KV Mechelen",
                    AwayTeamScore = 0
                },
                CollectedVersion = new Match
                {
                    Date = new DateTime(),
                    HomeTeamName = "KRC Genk",
                    HomeTeamScore = 1,
                    AwayTeamName = "KRC Genk",
                    AwayTeamScore = 1
                }
            }
        };
    }
}
