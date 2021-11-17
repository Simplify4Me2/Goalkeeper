using GoalKeeper.Common.Application.IO;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.IO.Services
{
    public class BaseService
    {
        private readonly HttpClient _client;
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(HttpClient client)
        {
            _client = client;
        }

        // TODO: Use IHttpClientFactory to implement resilient HTTP requests
        // https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
        //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-6.0#consumption-patterns
        protected BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        protected BaseService(ServiceConfiguration configuration, string endpoint)
        {
            _client = new HttpClient(new HttpClientHandler())
            {
                BaseAddress = new Uri($"{configuration.BaseUrl}api/{endpoint}/")
            };

            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        protected async Task<Result<TResult>> DoQuery<TResult>(string route, CancellationToken cancellationToken)
        {
            var response = await _client
                .GetAsync(route, cancellationToken)
                .ConfigureAwait(false);

            return await response.Content
                .ReadAsAsync<Result<TResult>>(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
