using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.Ports
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Domain.ValueObjects.PlayedMatch>> GetResults(CancellationToken cancellationToken);

        Task<IEnumerable<Domain.ValueObjects.Fixture>> GetFixtures(int matchday, CancellationToken cancellationToken);

        Task<bool> Save(Domain.ValueObjects.PlayedMatch match, CancellationToken cancellationToken);
    }
}
