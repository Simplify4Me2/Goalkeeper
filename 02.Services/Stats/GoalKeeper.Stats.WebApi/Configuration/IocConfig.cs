using GoalKeeper.Stats.Application;
using GoalKeeper.Stats.Application.IO;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Infrastructure;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace GoalKeeper.Stats.WebApi.Configuration
{
    public class IocConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(IAmApplication), typeof(IAmApplicationIO), typeof(Startup));

            services.AddTransient<IStatsRepository, StatsRepository>();

            services.AddTransient<IDbConnection>(db => new SqlConnection(configuration.GetConnectionString("GoalKeeperDB")));
        }
    }
}
