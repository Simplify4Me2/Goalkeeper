using GoalKeeper.DataCollector.Application.IO.Services;
using GoalKeeper.Stats.Application.IO.Services;

namespace GoalKeeper.DataCollector.App.Data
{
    public class MatchService
    {
        private readonly IMatchService _matchService;
        private readonly IMatchWebScraperService _webScraper;

        public MatchService(IMatchService matchService, IMatchWebScraperService matchWebScraperService)
        {
            _matchService = matchService;
            _webScraper = matchWebScraperService;
        }

        public async Task<MatchComparison[]> GetMatches(int matchday)
        {
            var savedMatchday = await _matchService.AllMatches(matchday, CancellationToken.None);
            var webMatchday = await _webScraper.AllMatches(matchday, CancellationToken.None);
            MatchComparison[] matchComparisons = Merge(savedMatchday.Data, webMatchday.Data);
            return matchComparisons;
        }

        private MatchComparison[] Merge(Stats.Application.IO.DTOs.MatchdayDTO savedMatchday, Application.IO.DTOs.MatchdayDTO webMatchday)
        {
            List<MatchComparison> comparisons = new List<MatchComparison>();

            foreach (var match in savedMatchday.Matches)
            {
                int homeScore = 0;
                int awayScore = 0;
                MatchComparison comparison = new MatchComparison
                {
                    MatchId = (int)match.Id,
                    DatabaseVersion = new Match {
                        Date = match.Date,
                        HomeTeamName = match.HomeTeamName,
                        HomeTeamScore = int.TryParse(match.HomeTeamScore, out homeScore) ? homeScore : 0,
                        AwayTeamName = match.AwayTeamName,
                        AwayTeamScore = int.TryParse(match.AwayTeamScore, out awayScore) ? awayScore : 0
                    }
                };

                var comparableMatch = webMatchday.Matches.FirstOrDefault(webMatch => GetComparableName(webMatch.HomeTeamName) == GetComparableName(match.HomeTeamName));

                comparison.CollectedVersion = new Match
                {
                    Date = comparableMatch != null ? comparableMatch.Date : new DateTime(),
                    HomeTeamName = comparableMatch != null ? comparableMatch.HomeTeamName : "",
                    HomeTeamScore = comparableMatch != null ? comparableMatch.HomeTeamScore ?? 0 : 0,
                    AwayTeamName = comparableMatch != null ? comparableMatch.AwayTeamName : "",
                    AwayTeamScore = comparableMatch != null ? comparableMatch.AwayTeamScore ?? 0 : 0
                };

                comparisons.Add(comparison);
            }

            return comparisons.ToArray();
        }

        private string GetComparableName(string teamName)
        {
            switch (teamName)
            {
                case "Royal Antwerp FC":
                case "Antwerp":
                    return "Antwerp";
                case "STVV":
                case "Sint-Truidense VV":
                    return "STVV";
                case "Beerschot VA":
                case "Beerschot":
                    return "Beerschot";
                case "Standard Luik":
                case "Standard":
                    return "Standard";
                case "Oud-Heverlee Leuven":
                case "OH Leuven":
                    return "OHL";
                case "Royal Charleroi Sporting Club":
                case "Charleroi":
                    return "Charleroi";
                case "RSC Anderlecht":
                case "Anderlecht":
                    return "RSC Anderlecht";
                case "KAS Eupen":
                case "Eupen":
                    return "KAS Eupen";
                case "SV Zulte Waregem":
                case "Zulte Waregem":
                    return "Zulte Waregem";
                case "Union":
                case "Union SG":
                    return "Union";
                case "RFC Seraing":
                case "Seraing":
                    return "RFC Seraing";
                default:
                    return teamName;
            }
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
