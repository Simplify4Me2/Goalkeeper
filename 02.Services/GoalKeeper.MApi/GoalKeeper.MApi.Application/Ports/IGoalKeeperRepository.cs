using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.MApi.Application.Ports
{
    public interface IGoalKeeperRepository
    {
        Task<List<Domain.Models.Fixture>> GetFixtures(CancellationToken cancellationToken);

        Task<List<Domain.Models.Team>> GetTeams(CancellationToken cancellationToken);
    }
}
