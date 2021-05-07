using GoalKeeper.Stats.Application;
using GoalKeeper.Stats.Application.IO;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Infrastructure;
using GoalKeeper.Stats.Infrastructure.EventStore;
using GoalKeeper.Stats.EventStore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.WebApi.Configuration
{
    public class IocConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(IAmApplication), typeof(IAmApplicationIO), typeof(Startup));

            services.AddTransient<IStatsRepository, StatsRepository>();
            services.AddTransient<IEventStore, MyEventStore>();

            services.AddTransient<IDbConnection>(db => new SqlConnection(configuration.GetConnectionString("GoalKeeperDB")));

            //services.AddSingleton<IStatsRepository>(InitializeCosmosClientInstanceAsync(configuration.GetSection("CosmosDb")).GetAwaiter().GetResult());
        }

        /// <summary>
        /// Creates a Cosmos DB database and a container with the specified partition key. 
        /// </summary>
        /// <returns></returns>
        private static async Task<CosmosRepository> InitializeCosmosClientInstanceAsync(IConfigurationSection configurationSection)
        {
            string databaseName = configurationSection.GetSection("DatabaseName").Value;
            string containerName = configurationSection.GetSection("ContainerName").Value;
            string account = configurationSection.GetSection("Account").Value;
            string key = configurationSection.GetSection("Key").Value;
            CosmosClient client = new CosmosClient(account, key);
            CosmosRepository cosmosDbService = new CosmosRepository(client, databaseName, containerName);
            DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
            await database.Database.CreateContainerIfNotExistsAsync(containerName, "/Stats");

            return cosmosDbService;
        }
    }
}
