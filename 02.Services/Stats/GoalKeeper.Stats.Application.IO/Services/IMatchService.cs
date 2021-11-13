using GoalKeeper.Common.Application.IO;
using GoalKeeper.Stats.Application.IO.DTOs;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.IO.Services
{
    public interface IMatchService
    {
        Task<Result<MatchdayDTO>> AllMatches(int matchday);
    }
}
