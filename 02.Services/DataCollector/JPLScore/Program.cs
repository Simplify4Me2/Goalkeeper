using GoalKeeper.Stats.Application.IO.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

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

        //var foo = Task.Run(() => service.AllMatches(5, new CancellationTokenSource().Token));
        //var foo = service.AllMatches(5, new CancellationTokenSource().Token).Result;

        //service.get
        //var matches = MatchCollectorSporza.GetMatchesFromMatchday(5);
        var matches = MatchCollectorProLeague.GetMatchesFromMatchday(5);

        Formatter.ConsoleWrite(matches);
        Formatter.WriteToFileAsSQL(matches);

        //return host.RunAsync();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args).ConfigureServices(services =>
            services.AddTransient<IMatchService, MatchService>());
}
