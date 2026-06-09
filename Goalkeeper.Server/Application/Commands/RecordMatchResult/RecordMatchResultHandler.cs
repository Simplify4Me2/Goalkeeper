using Goalkeeper.Server.Application.Interfaces;
using Goalkeeper.Server.Core.Interfaces;

namespace Goalkeeper.Server.Application.Commands.RecordMatchResult;

public class RecordMatchResultHandler(
    IMatchRepository matchRepository,
    IStandingsSyncService standingsSyncService) : ICommandHandler<RecordMatchResultCommand>
{
    public async Task HandleAsync(RecordMatchResultCommand command, CancellationToken cancellationToken)
    {
        var match = await matchRepository.GetByIdAsync(command.MatchId, cancellationToken)
            ?? throw new KeyNotFoundException($"Match {command.MatchId} not found.");

        match.RecordResult(command.HomeScore, command.AwayScore);

        await matchRepository.SaveAsync(cancellationToken);

        await standingsSyncService.RecalculateGroupAsync(match.GroupName, cancellationToken);
    }
}
