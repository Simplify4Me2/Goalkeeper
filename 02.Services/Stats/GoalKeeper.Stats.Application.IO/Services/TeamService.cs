using GoalKeeper.Common.Application.IO;
using GoalKeeper.Common.Application.IO.Services;
using GoalKeeper.Stats.Application.IO.DTOs;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.IO.Services
{
    public class TeamService : BaseService, ITeamService
    {
        // https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
        public TeamService(HttpClient httpClient) 
            : base(httpClient)
        {
        }

        public async Task<Result<MatchDTO>> FindTeam(string teamName, CancellationToken cancellationToken)
        {
            return await DoQuery<MatchDTO>($"{teamName}", cancellationToken);
        }
    }
}
