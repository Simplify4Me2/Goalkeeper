using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoalKeeper.Stats.IntegrationTests
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Startup>
    {
        public IConfiguration Configuration { get; private set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                Configuration = new ConfigurationBuilder().AddJsonFile("integrationsettings.json").Build();

                config.AddConfiguration(Configuration);
            });
            builder.ConfigureTestServices(services =>
            {
                services.AddTransient<IMatchRepository, MatchRepositoryStub>();
            });
        }
    }

    public class MatchRepositoryStub : IMatchRepository
    {
        public Task<IEnumerable<Match>> FindByMatchday(int matchday, CancellationToken cancellationToken)
        {
            var returnValue = new List<Match>
            {
                new Match(1, new (1, "Team 1", new(1, "Test stadium 1"), new List<Player> { }), new(2, "Team 2", new(2, "Test Stadium 2"), new List<Player> {}), null, new DateTime(2021, 09, 03), 1),
            };
            return Task.FromResult(returnValue.Select(fixture => fixture));
        }

        public Task<IEnumerable<Match>> Get(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Save(Match match, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
