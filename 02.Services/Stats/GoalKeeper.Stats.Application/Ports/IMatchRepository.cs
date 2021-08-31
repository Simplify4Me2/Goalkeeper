using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.Ports
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Domain.ValueObjects.PlayedMatch>> Get(CancellationToken cancellationToken);

        Task<bool> Save(Domain.ValueObjects.PlayedMatch match, CancellationToken cancellationToken);
    }
}
