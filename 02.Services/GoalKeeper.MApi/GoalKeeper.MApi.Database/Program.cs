using DbUp;
using DbUp.Engine;
using DbUp.Helpers;
using System;
using System.Configuration;
using System.Linq;

namespace GoalKeeper.MApi.Database
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var connectionString =
                args.FirstOrDefault()
                ?? ConfigurationManager.ConnectionStrings["GoalKeeperDB"]?.ConnectionString;

            Console.WriteLine(connectionString);

            // Create database if not exist
            EnsureDatabase.For.SqlDatabase(connectionString);

            EnsureSchemaForJournal(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .JournalToSqlTable("GoalKeeper", "Migrations")
                    .WithScriptsFromFileSystem("./Migrations")
                    .WithTransactionPerScript()
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

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

            Console.WriteLine("Would you like to seed the database? (y/N)");
            var key = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine(key.KeyChar);

            if (key.KeyChar == 'y')
            {
                var seeder =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .JournalToSqlTable("GoalKeeper", "Seeds")
                    .WithScriptsFromFileSystem("./Seeds")
                    .WithTransactionPerScript()
                    .LogToConsole()
                    .Build();

                Console.WriteLine("Seeding the database...");
                var seedResult = seeder.PerformUpgrade();

                if (!seedResult.Successful)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(result.Error);
                    Console.ResetColor();
#if DEBUG
                    Console.ReadLine();
#endif
                    return -1;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }

        /// <summary>
        /// DBUp 'JournalToSqlTable' does not create a schema in a new database.
        /// First we make sure our schema exists.
        /// </summary>
        /// <param name="connectionString"></param>
        private static void EnsureSchemaForJournal(string connectionString)
        {
            DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScript(SqlScript.FromFile("./Migrations/202011022114_EnsureSchemaExists.sql"))
                .JournalTo(new NullJournal())
                .Build()
                .PerformUpgrade();
        }
    }
}
