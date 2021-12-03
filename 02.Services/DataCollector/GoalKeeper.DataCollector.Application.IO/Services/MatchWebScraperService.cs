using GoalKeeper.Common.Application.IO.Services;
using System.Net.Http;

namespace GoalKeeper.DataCollector.Application.IO.Services
{
    public class MatchWebScraperService : BaseService, IMatchWebScraperService
    {
        public MatchWebScraperService(ServiceConfiguration config, IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
