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
            services.AddTransient<IDbConnection>(db => new SqlConnection(configuration.GetConnectionString("GoalKeeperDB")));
        }
    }
}
