using DbUp;
using DbUp.Engine;
using DbUp.Helpers;
using System;
using System.Configuration;
using System.Linq;

namespace GoalKeeper.Stats.Database.Seed
{
    class Program
    {
        static int Main(string[] args)
        {
            var connectionString =
                args.FirstOrDefault()
                ?? ConfigurationManager.ConnectionStrings["GoalKeeperDB"]?.ConnectionString;

            Console.WriteLine(connectionString);

            // Create database if not exist
            EnsureDatabase.For.SqlDatabase(connectionString);

            var seeder =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .JournalToSqlTable("GoalKeeper", "Seeds")
                    .WithScriptsFromFileSystem("./Seeds")
                    .WithTransactionPerScript()
                    .LogToConsole()
                    .Build();

            var result = seeder.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
