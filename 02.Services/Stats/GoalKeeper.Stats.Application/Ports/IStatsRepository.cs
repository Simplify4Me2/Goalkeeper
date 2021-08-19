using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.Ports
{
    public interface IStatsRepository
    {
        Task<IEnumerable<Domain.ValueObjects.Team>> GetTeams(CancellationToken cancellationToken);
        
        Task<Domain.ValueObjects.Team> GetTeamById(long id, CancellationToken cancellationToken);

        Task<Domain.ValueObjects.Team> GetTeamByName(string name, CancellationToken cancellationToken);

        Task<IEnumerable<Domain.ValueObjects.Player>> GetPlayersByTeamId(long teamId, CancellationToken cancellationToken);
    }
}
