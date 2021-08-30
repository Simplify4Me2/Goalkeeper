using GoalKeeper.Common.Application.IO;
using GoalKeeper.Stats.Application.IO.DTOs;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.IO.Services
{
    public class TeamService : BaseService, ITeamService
    {
        private readonly HttpClient _client;

        public TeamService(HttpClient client) : base(client)
        {
            //_client = client;
            //_client = new HttpClient(new HttpClientHandler())
            //{
            //    BaseAddress = new Uri("http://localhost:5010/api/team/")
            //};
        }

        public async Task<Result<MatchDTO>> GetTeam(string teamName, CancellationToken cancellationToken)
        {
            //_client = new HttpClient(new HttpClientHandler())
            //{
            //    BaseAddress = new Uri("http://localhost:5010/api/team/")
            //};

            //var route = "";
            //var response = await _client.GetAsync(route, cancellationToken).ConfigureAwait(false);

            ////return await response.Content.ReadAsAsync<Result<MatchDTO>>(cancellationToken)
            //return await response.Content.ReadAsAsync<Result<MatchDTO>>(cancellationToken).ConfigureAwait(false);

            return await DoQuery<MatchDTO>($"{teamName}", cancellationToken);
        }
    }
}
