namespace Goalkeeper.Server.Application.Commands.RecordMatchResult;

public record RecordMatchResultCommand(int MatchId, int HomeScore, int AwayScore);
