using Goalkeeper.Server.Core.Aggregates;

namespace Goalkeeper.Server.Core.Interfaces;

public interface IMatchRepository
{
    Task<Match?> GetByIdAsync(int matchId, CancellationToken cancellationToken);
    Task SaveAsync(CancellationToken cancellationToken);
}
