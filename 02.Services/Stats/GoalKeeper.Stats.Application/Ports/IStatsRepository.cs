using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.Ports
{
    public interface IStatsRepository
    {
        Task<Domain.Entities.Ranking> GetRanking(CancellationToken cancellationToken);

        Task<IEnumerable<Domain.Entities.Team>> GetTeams(CancellationToken cancellationToken);
        
        Task<Domain.Entities.Team> GetTeamById(long id, CancellationToken cancellationToken);
    }
}
