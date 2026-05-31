using Goalkeeper.Server.Core.Entities;

public interface ITeamsRepository
{
    Task<IEnumerable<Team>> Get(CancellationToken cancellationToken);
}