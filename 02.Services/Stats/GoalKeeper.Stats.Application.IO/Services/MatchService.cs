using GoalKeeper.Common.Application.IO;
using GoalKeeper.Stats.Application.IO.DTOs;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.IO.Services
{
    public class MatchService : BaseService, IMatchService
    {

        public MatchService(HttpClient httpClient)
            : base(httpClient)
        {
        }

        public MatchService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {

        }

        public async Task<Result<MatchdayDTO>> AllMatches(int matchday, CancellationToken cancellationToken)
        {
            return await DoQuery<MatchdayDTO>($"matchday/{matchday}", cancellationToken);
        }
    }
}
