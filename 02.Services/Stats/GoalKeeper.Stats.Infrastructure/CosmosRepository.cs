using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain.Entities;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Infrastructure
{
    public class CosmosRepository : IStatsRepository
    {
        private Container _container;

        public CosmosRepository(CosmosClient dbClient, string databaseName, string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public Task<IEnumerable<Player>> GetPlayersByTeamId(long teamId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Ranking> GetRanking(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetTeamById(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Team>> GetTeams(CancellationToken cancellationToken)
        {
            //try
            //{
            //    Console.WriteLine("Beginning operations...\n");
            //    CosmosRepository p = new CosmosRepository();
            //    await p.GetStartedDemoAsync();

            //}
            //catch (CosmosException de)
            //{
            //    Exception baseException = de.GetBaseException();
            //    Console.WriteLine("{0} error occurred: {1}", de.StatusCode, de);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Error: {0}", e);
            //}
            //finally
            //{
            //    Console.WriteLine("End of demo.");
            //    //Console.ReadKey();
            //}
            //return Task.FromResult(()new List<Team>());
            //return new List<Team>();
            throw new NotImplementedException();
        }

        //private async Task GetStartedDemoAsync()
        //{
        //    // Create a new instance of the Cosmos Client
        //    this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);

        //    await this.CreateDatabaseAsync();

        //    await this.CreateContainerAsync();

        //}

        /// <summary>
        /// Create the database if it does not exist
        /// </summary>
        //private async Task CreateDatabaseAsync()
        //{
        //    // Create a new database
        //    this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
        //    Console.WriteLine("Created Database: {0}\n", this.database.Id);
        //}

        /// <summary>
        /// Create the container if it does not exist. 
        /// Specifiy "/LastName" as the partition key since we're storing family information, to ensure good distribution of requests and storage.
        /// </summary>
        /// <returns></returns>
        //private async Task CreateContainerAsync()
        //{
        //    // Create a new container
        //    this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/Stats");
        //    Console.WriteLine("Created Container: {0}\n", this.container.Id);
        //}

    }
}
