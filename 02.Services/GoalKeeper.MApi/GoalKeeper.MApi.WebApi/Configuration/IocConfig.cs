using GoalKeeper.MApi.Application;
using GoalKeeper.MApi.Application.IO;
using GoalKeeper.MApi.Application.Ports;
using GoalKeeper.MApi.Infrastructure;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace GoalKeeper.MApi.WebApi.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class IocConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(IAmApplication), typeof(IAmApplicationIO), typeof(Startup));

            services.AddTransient<IGoalKeeperRepository, GoalKeeperRepository>();

            services.AddTransient<IDbConnection>(db => new SqlConnection(configuration.GetConnectionString("GoalKeeperDB")));
        }
    }
}
