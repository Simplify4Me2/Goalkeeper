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
            Console.WriteLine($"{match.Date.ToString("g")} - {match.HomeTeamName} vs {match.AwayTeamName}: {match.HomeTeamScore} - {match.AwayTeamScore}");
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
            sb.AppendLine($"    ({MapTeam(match.HomeTeamName)}, {match.HomeTeamScore}, {MapTeam(match.AwayTeamName)}, {match.AwayTeamScore}, {match.Matchday}, '2020-08-08 16:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),");
        }

        writer.WriteLine(sb.ToString());
    }

    private static string MapTeam(string homeTeamName)
    {
        switch (homeTeamName)
        {
            case "Standard de Liège":
                return "@StandardLuik";
            case "OH Leuven":
                return "@OHL";
            case "STVV":
                return "@STVV";
            case "Sporting Charleroi":
                return "@Charleroi";
            case "K. Beerschot V.A.":
                return "@Beerschot";
            case "Royale Union Saint-Gilloise":
                return "@Union";
            case "SV Zulte Waregem":
                return "@ZulteWaregem";
            case "RSC Anderlecht":
                return "@Anderlecht";
            case "Royal Antwerp FC":
                return "@Antwerp";
            case "Cercle Brugge":
                return "@CercleBrugge";
            case "Club Brugge":
                return "@ClubBrugge";
            case "KAS Eupen":
                return "@Eupen";
            case "KV Mechelen":
                return "@Mechelen";
            case "KV Kortrijk":
                return "@Kortrijk";
            case "KV Oostende":
                return "@Oostende";
            case "KAA Gent":
                return "@Gent";
            case "KRC Genk":
                return "@Genk";
            case "RFC Seraing":
                return "@Seraing";
            default:
                return null;
        }
    }
}
