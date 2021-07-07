using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.Ports
{
    public interface IStatsRepository
    {
        Task<IEnumerable<Domain.Entities.Team>> GetTeams(CancellationToken cancellationToken);
        
        Task<Domain.Entities.Team> GetTeamById(long id, CancellationToken cancellationToken);

        Task<Domain.Entities.Team> GetTeamByName(string name, CancellationToken cancellationToken);

        Task<IEnumerable<Domain.Entities.Player>> GetPlayersByTeamId(long teamId, CancellationToken cancellationToken);

        Task<IEnumerable<Domain.Entities.Match>> GetMatches(CancellationToken cancellationToken);
    }
}
