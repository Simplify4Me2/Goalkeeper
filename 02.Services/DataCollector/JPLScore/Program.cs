namespace JPLScore;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        // https://referbruv.com/blog/posts/dependency-injection-in-a-net-core-console-application

        //var matches = MatchCollectorSporza.GetMatchesFromMatchday(5);

        var matches = MatchCollectorProLeague.GetMatchesFromMatchday(5);

        Formatter.ConsoleWrite(matches);
        Formatter.WriteToFileAsSQL(matches);
    }
}
