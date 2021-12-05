using GoalKeeper.Common.Application.IO.Services;
using GoalKeeper.DataCollector.Application.IO.Services;
using GoalKeeper.Stats.Application.IO.Services;

namespace GoalKeeper.DataCollector.App.Configuration
{
    internal static class IocConfig
    {
        public static void ConfigureExternalServices(IServiceCollection services, IConfiguration configuration)
        {
            //var statsConfiguration = new ServiceConfiguration();
            //configuration.Bind("StatsAPI", statsConfiguration);

            //services.AddScoped<IMatchService, MatchService>(provider => new MatchService(statsConfiguration, provider.GetService<IHttpClientFactory>()));

            //var dataCollectorConfiguration = new ServiceConfiguration();
            //configuration.Bind("DataCollectorAPI", dataCollectorConfiguration);

            //services.AddScoped<IMatchWebScraperService, MatchWebScraperService>(provider => new MatchWebScraperService(dataCollectorConfiguration, provider.GetService<IHttpClientFactory>()));
        }
    }
}
