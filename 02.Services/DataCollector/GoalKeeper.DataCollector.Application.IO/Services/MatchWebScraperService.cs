using GoalKeeper.Common.Application.IO;
using GoalKeeper.Common.Application.IO.Services;
using GoalKeeper.DataCollector.Application.IO.DTOs;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.DataCollector.Application.IO.Services
{
    public class MatchWebScraperService : BaseService, IMatchWebScraperService
    {
        //public MatchWebScraperService(ServiceConfiguration config, IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        //{
        //}

        public MatchWebScraperService(HttpClient httpClient) : base(httpClient)
        {

        }

        public async Task<Result<MatchdayDTO>> AllMatches(int matchday, CancellationToken cancellationToken)
        {
            return await DoQuery<MatchdayDTO>($"/match/{matchday}", cancellationToken);
        }
    }
}
