using GoalKeeper.Stats.Application;
using GoalKeeper.Stats.Application.IO;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoalKeeper.Stats.WebApi.Configuration
{
    public class IocConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(IAmApplication), typeof(IAmApplicationIO), typeof(Startup));

            //services.AddTransient<IGoalKeeperRepository, GoalKeeperRepository>();

            //services.AddTransient<IDbConnection>(db => new SqlConnection(configuration.GetConnectionString("GoalKeeperDB")));
        }
    }
}
