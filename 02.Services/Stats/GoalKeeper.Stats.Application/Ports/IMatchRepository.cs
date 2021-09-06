using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.Ports
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Domain.Match>> Get(CancellationToken cancellationToken);

        Task<IEnumerable<Domain.Match>> FindByMatchday(int matchday, CancellationToken cancellationToken);

        Task<bool> Save(Domain.Match match, CancellationToken cancellationToken);
    }
}
