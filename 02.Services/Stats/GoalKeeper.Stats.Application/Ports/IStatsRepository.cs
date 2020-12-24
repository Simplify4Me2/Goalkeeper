using GoalKeeper.Stats.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.Ports
{
    public interface IStatsRepository
    {
        Task<Domain.Models.Ranking> Get(CancellationToken cancellationToken);
    }
}
