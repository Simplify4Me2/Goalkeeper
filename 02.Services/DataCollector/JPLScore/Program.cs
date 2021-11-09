using System;

namespace JPLScore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // https://referbruv.com/blog/posts/dependency-injection-in-a-net-core-console-application

            var matches = MatchCollector.GetMatchesFromMatchday(5);

            Console.WriteLine(matches);
        }
    }
}
