using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.Ports
{
    public interface IStatsRepository
    {
        Task<IEnumerable<Domain.Team>> GetTeams(CancellationToken cancellationToken);
        
        Task<Domain.Team> GetTeamById(long id, CancellationToken cancellationToken);

        Task<Domain.Team> GetTeamByName(string name, CancellationToken cancellationToken);

        Task<IEnumerable<Domain.Player>> GetPlayersByTeamId(long teamId, CancellationToken cancellationToken);
    }
}
