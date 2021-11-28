using GoalKeeper.DataCollector.Domain;
using GoalKeeper.DataCollector.Infrastructure.Repositories;
using GoalKeeper.Stats.Application.IO.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Net.Http;

namespace JPLScore;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        // https://referbruv.com/blog/posts/dependency-injection-in-a-net-core-console-application

        using IHost host = CreateHostBuilder(args).Build();

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost");
        IMatchService service = new MatchService(client);

        var contextOptions = new DbContextOptionsBuilder<MatchDbContext>()
    .UseSqlServer(@"Data Source=.;Initial Catalog=DataCollectorDB;User Id=sqladmin;Password=txCnJqOynDfQaEbHpgNJ;Application Name=DataCollector.Database")
    .Options;
        SQLRepository repository = new SQLRepository(new MatchDbContext(contextOptions));

        //var foo = Task.Run(() => service.AllMatches(5, new CancellationTokenSource().Token));
        //var foo = service.AllMatches(5, new CancellationTokenSource().Token).Result;

        List<Match> allMatches = new List<Match>();
        for (int i = 1; i < 35; i++)
        {
            var matches = MatchCollectorVoetbalkrant.GetMatchesFromMatchday(i);

            repository.Save(matches.ToArray()).ConfigureAwait(false);
            Formatter.ConsoleWrite(matches);
            allMatches.AddRange(matches);
        }

        Formatter.WriteToFileAsSQL(allMatches);

        //return host.RunAsync();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args).ConfigureServices(services =>
            services.AddTransient<IMatchService, MatchService>());
}
