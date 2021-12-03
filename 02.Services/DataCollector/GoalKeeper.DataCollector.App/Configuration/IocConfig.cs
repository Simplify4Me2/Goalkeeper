using GoalKeeper.Common.Application.IO.Services;
using GoalKeeper.Stats.Application.IO.Services;

namespace GoalKeeper.DataCollector.App.Configuration
{
    internal static class IocConfig
    {
        public static void ConfigureExternalServices(IServiceCollection services, IConfiguration configuration)
        {
            var statsConfiguration = new ServiceConfiguration();
            configuration.Bind("StatsAPI", statsConfiguration);

            services.AddScoped<IMatchService, MatchService>(provider => new MatchService(statsConfiguration, provider.GetService<IHttpClientFactory>()));
        }
    }
}
