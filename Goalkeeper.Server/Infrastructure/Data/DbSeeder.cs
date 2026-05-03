using Goalkeeper.Server.Core;
using Microsoft.EntityFrameworkCore;

namespace Goalkeeper.Server.Infrastructure.Data;

public static class DbSeeder
{
    private static readonly string[] TeamNames =
    [
        // Group A
        "Mexico", "South Africa", "South Korea", "Czech Republic",
        // Group B
        "Canada", "Bosnia & Herzegovina", "Qatar", "Switzerland",
        // Group C
        "Brazil", "Morocco", "Haiti", "Scotland",
        // Group D
        "USA", "Paraguay", "Australia", "Turkey",
        // Group E
        "Germany", "Curaçao", "Ivory Coast", "Ecuador",
        // Group F
        "Netherlands", "Japan", "Sweden", "Tunisia",
        // Group G
        "Belgium", "Egypt", "Iran", "New Zealand",
        // Group H
        "Spain", "Cape Verde", "Saudi Arabia", "Uruguay",
        // Group I
        "France", "Senegal", "Iraq", "Norway",
        // Group J
        "Argentina", "Algeria", "Austria", "Jordan",
        // Group K
        "Portugal", "DR Congo", "Uzbekistan", "Colombia",
        // Group L
        "England", "Croatia", "Ghana", "Panama",
    ];

    public static async Task SeedTeamsAsync(GoalkeeperDbContext context)
    {
        if (await context.Teams.AnyAsync())
            return;

        context.Teams.AddRange(TeamNames.Select(name => new Team { Name = name }));
        await context.SaveChangesAsync();
    }
}
