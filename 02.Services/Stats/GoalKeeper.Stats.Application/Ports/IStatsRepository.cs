using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.Ports
{
    public interface IStatsRepository
    {
        Task<Domain.Entities.Ranking> GetRanking(CancellationToken cancellationToken);
    }
}
