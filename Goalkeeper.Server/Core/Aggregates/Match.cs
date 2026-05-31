using Goalkeeper.Server.Core.Entities;
using Goalkeeper.Server.Core.Enums;

namespace Goalkeeper.Server.Core.Aggregates;

public class Match
{
    public int Id { get; private set; }
    public int HomeTeamId { get; private set; }
    public int AwayTeamId { get; private set; }
    public string GroupName { get; private set; } = string.Empty;
    public string Stage { get; private set; } = string.Empty;
    public DateTime KickoffUtc { get; private set; }
    public MatchStatus Status { get; private set; }
    public int? HomeScore { get; private set; }
    public int? AwayScore { get; private set; }

    // Navigation properties for EF Core
    public Team? HomeTeam { get; private set; }
    public Team? AwayTeam { get; private set; }

    // Parameterless constructor required by EF Core
    private Match() { }

    public static Match Schedule(
        int homeTeamId,
        int awayTeamId,
        string groupName,
        string stage,
        DateTime kickoffUtc)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(groupName);
        ArgumentException.ThrowIfNullOrWhiteSpace(stage);

        return new Match
        {
            HomeTeamId = homeTeamId,
            AwayTeamId = awayTeamId,
            GroupName = groupName,
            Stage = stage,
            KickoffUtc = kickoffUtc,
            Status = MatchStatus.Scheduled
        };
    }

    public void RecordResult(int homeScore, int awayScore)
    {
        if (homeScore < 0 || awayScore < 0)
            throw new ArgumentException("Scores cannot be negative.");

        HomeScore = homeScore;
        AwayScore = awayScore;
        Status = MatchStatus.Completed;
    }

    public void SetLive() => Status = MatchStatus.Live;
}
