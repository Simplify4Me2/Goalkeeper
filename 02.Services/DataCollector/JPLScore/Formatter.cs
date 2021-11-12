using GoalKeeper.Stats.Application.IO.CommandModels;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JPLScore;
internal class Formatter
{
    public static void ConsoleWrite(List<MatchPlayedModel> matches)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        foreach (var match in matches)
        {
            Console.WriteLine($"{match.Date.ToString("f")} - {match.HomeTeamName} vs {match.AwayTeamName}: {match.HomeTeamScore} - {match.AwayTeamScore}");
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void WriteToFileAsSQL(List<MatchPlayedModel> matches)
    {
        string docPath = "D:\\Git\\Goalkeeper\\02.Services\\DataCollector";

        using StreamWriter writer = new StreamWriter(Path.Combine(docPath, "WriteText.txt"));

        StringBuilder sb = new StringBuilder("INSERT INTO [Stats].[Matches]");
        sb.AppendLine("    ([HomeTeamId], [HomeTeamScore], [AwayTeamId], [AwayTeamScore], [Matchday], [DateUtc], CreatedUtc, CreatedBy, ModifiedUtc, ModifiedBy)");
        sb.AppendLine("VALUES");

        foreach (var match in matches)
        {
            sb.AppendLine($"    ((SELECT Id FROM Stats.Teams WHERE[Name] like '%Club Brugge%'), {match.HomeTeamScore}, (SELECT Id FROM Stats.Teams WHERE[Name] like '%Royal Charleroi Sporting Club%'), {match.AwayTeamScore}, {match.Matchday}, '2020-08-08 16:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),");
        }

        writer.WriteLine(sb.ToString());
    }
}
