using GoalKeeper.DataCollector.Application.IO.Services;
using GoalKeeper.Stats.Application.IO.Services;

namespace GoalKeeper.DataCollector.App.Data
{
    public class MatchService
    {
        private readonly IMatchService _matchService;
        private readonly IMatchWebScraperService _webScraper;

        public MatchService(IMatchService matchService, IMatchWebScraperService matchWebScraperService)
        //public MatchService()
        {
            _matchService = matchService;
            _webScraper = matchWebScraperService;
        }

        public async Task<MatchComparison[]> GetMatches(int matchday)
        {
            var foo = await _matchService.AllMatches(matchday, CancellationToken.None);
            var bar = await _webScraper.AllMatches(matchday, CancellationToken.None);
            return FakeDBMatches;
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
