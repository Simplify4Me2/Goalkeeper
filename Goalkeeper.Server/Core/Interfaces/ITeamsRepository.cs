using Goalkeeper.Server.Core;

public interface ITeamsRepository
{
    Task<IEnumerable<Team>> Get(CancellationToken cancellationToken);
}