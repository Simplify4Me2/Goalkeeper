using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.Ports
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Domain.Entities.Match>> Get(CancellationToken cancellationToken);

        Task<bool> Save(Domain.Entities.Match match, CancellationToken cancellationToken);
    }
}
