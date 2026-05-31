using Goalkeeper.Server.Core.Models;

namespace Goalkeeper.Server.Core.Interfaces;

public interface IStandingsRepository
{
    Task<IEnumerable<TeamStanding>> GetAllAsync(CancellationToken cancellationToken);
    Task<IEnumerable<TeamStanding>> GetByGroupAsync(string groupName, CancellationToken cancellationToken);
}
