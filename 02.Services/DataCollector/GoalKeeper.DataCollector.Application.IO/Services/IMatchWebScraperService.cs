using GoalKeeper.Common.Application.IO;
using GoalKeeper.DataCollector.Application.IO.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.DataCollector.Application.IO.Services
{
    public interface IMatchWebScraperService
    {
        Task<Result<MatchdayDTO>> AllMatches(int matchday, CancellationToken cancellationToken);
    }
}
