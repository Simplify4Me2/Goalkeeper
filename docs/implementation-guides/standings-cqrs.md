# Standings Feature — CQRS Implementation Guide

## Overview

This guide walks through implementing the `STANDINGS` backend using the **Command Query Responsibility Segregation (CQRS)** pattern, aligned with the existing Clean Architecture and DDD principles in `Goalkeeper.Server`.

### What we are building

| Layer | What gets added |
|---|---|
| **Core** | `Match` aggregate, `StandingStats` value object, `TeamStandingReadModel` read model |
| **Application** | Handler interfaces, two query handlers, one command handler, DTOs |
| **Infrastructure** | `MatchRepository`, `StandingsReadRepository`, `StandingsSyncService` |
| **API** | `GET /api/standings` and `GET /api/standings/{group}` |
| **Frontend** | `useStandings` hook, standings types, Dashboard wired to API |

### CQRS data flow

```
[POST /api/matches/{id}/result]
        │
        ▼
RecordMatchResultCommand
        │
        ▼
RecordMatchResultHandler
   ├── Match.RecordResult()     ← Write model (source of truth)
   └── StandingsSyncService     ← Recalculates read model
              │
              ▼
       TeamStandingReadModel    ← Denormalized standings table
              │
              ▼
[GET /api/standings/{group}]
        │
        ▼
GetGroupStandingsHandler        ← Fast read, no joins, no math
```

### Key design decisions

1. **No third-party CQRS library.** Handlers implement lightweight `IQueryHandler<TQuery, TResult>` and `ICommandHandler<TCommand>` interfaces defined in `Application/Abstractions/`. Controllers inject handlers directly — no mediator bus needed at this scale.
2. `Match` is the aggregate root for the write side. It enforces invariants (e.g., scores can't be negative).
3. `TeamStandingReadModel` is a **denormalized read model** — never computed at query time, only on write.
4. Standings sync is **synchronous**: it happens inside the same request after a result is recorded. This keeps consistency simple without an event bus.
5. Analytics metrics (`Possession`, `Defense`, `Attack`, `Passing`, `Pressing`) are stubbed as nullable columns — they are not populated yet but the schema supports them.

---

## Phase 1 — Domain Layer (`Core/`)

> Pure C# — no framework dependencies. These are the heart of the domain.

### Step 1: Add `Flag` to the `Team` entity

- [x] Open `Core/Team.cs`
- [x] Add `public string Flag { get; set; } = string.Empty;`

```csharp
// Core/Team.cs
using System.ComponentModel.DataAnnotations;

namespace Goalkeeper.Server.Core;

public class Team
{
    [Required]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public string Flag { get; set; } = string.Empty;
}
```

---

### Step 2: Create the `MatchStatus` enum

- [x] Create folder `Core/Enums/`
- [x] Create `Core/Enums/MatchStatus.cs`

```csharp
// Core/Enums/MatchStatus.cs
namespace Goalkeeper.Server.Core.Enums;

public enum MatchStatus
{
    Scheduled,
    Live,
    Completed
}
```

---

### Step 3: Create the `StandingStats` value object

This record encapsulates all standings arithmetic. Points and goal difference are always derived — never stored independently — so they can never diverge.

- [x] Create folder `Core/ValueObjects/`
- [x] Create `Core/ValueObjects/StandingStats.cs`

```csharp
// Core/ValueObjects/StandingStats.cs
namespace Goalkeeper.Server.Core.ValueObjects;

public class StandingStats(int Played, int Won, int Drawn, int Lost, int GoalsFor, int GoalsAgainst)
{
    public int Points => (Won * 3) + Drawn;
    public int GoalDifference => GoalsFor - GoalsAgainst;

    public static StandingStats Zero => new(0, 0, 0, 0, 0, 0);

    public StandingStats AddWin(int scored, int conceded) =>
        this with { Played = Played + 1, Won = Won + 1, GoalsFor = GoalsFor + scored, GoalsAgainst = GoalsAgainst + conceded };

    public StandingStats AddDraw(int scored, int conceded) =>
        this with { Played = Played + 1, Drawn = Drawn + 1, GoalsFor = GoalsFor + scored, GoalsAgainst = GoalsAgainst + conceded };

    public StandingStats AddLoss(int scored, int conceded) =>
        this with { Played = Played + 1, Lost = Lost + 1, GoalsFor = GoalsFor + scored, GoalsAgainst = GoalsAgainst + conceded };
}
```

---

### Step 4: Create the `Match` aggregate root

`Match` is the authoritative write model. It owns result invariants and replaces the thin `Fixture` entity for this domain concept. It uses private setters to protect its state — only its own methods can mutate it.

- [x] Create folder `Core/Aggregates/`
- [x] Create `Core/Aggregates/Match.cs`

```csharp
// Core/Aggregates/Match.cs
using Goalkeeper.Server.Core.Enums;

namespace Goalkeeper.Server.Core.Aggregates;

public class Match
{
    public int Id { get; private set; }
    public int HomeTeamId { get; private set; }
    public int AwayTeamId { get; private set; }
    public string GroupName { get; private set; } = string.Empty;
    public string Stage { get; private set; } = string.Empty;
    public DateTime KickoffUtc { get; private set; }
    public MatchStatus Status { get; private set; }
    public int? HomeScore { get; private set; }
    public int? AwayScore { get; private set; }

    // Navigation properties for EF Core
    public Team? HomeTeam { get; private set; }
    public Team? AwayTeam { get; private set; }

    // Parameterless constructor required by EF Core
    private Match() { }

    public static Match Schedule(
        int homeTeamId,
        int awayTeamId,
        string groupName,
        string stage,
        DateTime kickoffUtc)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(groupName);
        ArgumentException.ThrowIfNullOrWhiteSpace(stage);

        return new Match
        {
            HomeTeamId = homeTeamId,
            AwayTeamId = awayTeamId,
            GroupName = groupName,
            Stage = stage,
            KickoffUtc = kickoffUtc,
            Status = MatchStatus.Scheduled
        };
    }

    public void RecordResult(int homeScore, int awayScore)
    {
        if (homeScore < 0 || awayScore < 0)
            throw new ArgumentException("Scores cannot be negative.");

        HomeScore = homeScore;
        AwayScore = awayScore;
        Status = MatchStatus.Completed;
    }

    public void SetLive() => Status = MatchStatus.Live;
}
```

---

### Step 5: Create the `TeamStandingReadModel` read model entity

This is **not** a domain aggregate. It is a persistence projection — a pre-calculated, denormalized row per team per group optimized for zero-computation reads.

- [ ] Create folder `Core/ReadModels/`
- [ ] Create `Core/ReadModels/TeamStandingReadModel.cs`

```csharp
// Core/ReadModels/TeamStandingReadModel.cs
namespace Goalkeeper.Server.Core.ReadModels;

public class TeamStandingReadModel
{
    public int Id { get; set; }
    public string GroupName { get; set; } = string.Empty;
    public int TeamId { get; set; }
    public string TeamName { get; set; } = string.Empty;
    public string TeamFlag { get; set; } = string.Empty;
    public int Played { get; set; }
    public int Won { get; set; }
    public int Drawn { get; set; }
    public int Lost { get; set; }
    public int GoalsFor { get; set; }
    public int GoalsAgainst { get; set; }
    public int Points { get; set; }

    // Nullable stubs — populated later when match statistics are tracked
    public int? Possession { get; set; }
    public int? Defense { get; set; }
    public int? Attack { get; set; }
    public int? Passing { get; set; }
    public int? Pressing { get; set; }
}
```

---

## Phase 2 — Application Layer: Abstractions

Instead of a third-party mediator bus, define two small generic interfaces. This gives the same decoupling benefits — handlers are independent of their callers — with zero additional dependencies.

### Step 6: Create `IQueryHandler` and `ICommandHandler`

- [ ] Create folder `Application/Abstractions/`
- [ ] Create `Application/Abstractions/IQueryHandler.cs`

```csharp
// Application/Abstractions/IQueryHandler.cs
namespace Goalkeeper.Server.Application.Abstractions;

public interface IQueryHandler<in TQuery, TResult>
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken ct);
}
```

- [ ] Create `Application/Abstractions/ICommandHandler.cs`

```csharp
// Application/Abstractions/ICommandHandler.cs
namespace Goalkeeper.Server.Application.Abstractions;

public interface ICommandHandler<in TCommand>
{
    Task HandleAsync(TCommand command, CancellationToken ct);
}
```

---

## Phase 3 — Application Layer: Queries

### Step 7: Create `GetGroupStandingsQuery` and its handler

- [ ] Create folder `Application/Queries/GetGroupStandings/`
- [ ] Create `Application/Queries/GetGroupStandings/GetGroupStandingsQuery.cs`

```csharp
// Application/Queries/GetGroupStandings/GetGroupStandingsQuery.cs
namespace Goalkeeper.Server.Application.Queries.GetGroupStandings;

public record GetGroupStandingsQuery(string GroupName);
```

- [ ] Create `Application/Queries/GetGroupStandings/GetGroupStandingsHandler.cs`

```csharp
// Application/Queries/GetGroupStandings/GetGroupStandingsHandler.cs
using Goalkeeper.Server.Application.Abstractions;
using Goalkeeper.Server.Application.DTOs;
using Goalkeeper.Server.Application.DTOs.Mappers;
using Goalkeeper.Server.Infrastructure.Repositories;

namespace Goalkeeper.Server.Application.Queries.GetGroupStandings;

public class GetGroupStandingsHandler(IStandingsReadRepository repository)
    : IQueryHandler<GetGroupStandingsQuery, IEnumerable<TeamStandingDto>>
{
    public async Task<IEnumerable<TeamStandingDto>> HandleAsync(
        GetGroupStandingsQuery query, CancellationToken ct)
    {
        var standings = await repository.GetByGroupAsync(query.GroupName, ct);
        return standings
            .OrderByDescending(s => s.Points)
            .ThenByDescending(s => s.GoalsFor - s.GoalsAgainst)
            .ThenByDescending(s => s.GoalsFor)
            .Select(s => s.ToDto());
    }
}
```

---

### Step 8: Create `GetAllGroupStandingsQuery` and its handler

- [ ] Create folder `Application/Queries/GetAllGroupStandings/`
- [ ] Create `Application/Queries/GetAllGroupStandings/GetAllGroupStandingsQuery.cs`

```csharp
// Application/Queries/GetAllGroupStandings/GetAllGroupStandingsQuery.cs
namespace Goalkeeper.Server.Application.Queries.GetAllGroupStandings;

public record GetAllGroupStandingsQuery;
```

- [ ] Create `Application/Queries/GetAllGroupStandings/GetAllGroupStandingsHandler.cs`

```csharp
// Application/Queries/GetAllGroupStandings/GetAllGroupStandingsHandler.cs
using Goalkeeper.Server.Application.Abstractions;
using Goalkeeper.Server.Application.DTOs;
using Goalkeeper.Server.Application.DTOs.Mappers;
using Goalkeeper.Server.Infrastructure.Repositories;

namespace Goalkeeper.Server.Application.Queries.GetAllGroupStandings;

public class GetAllGroupStandingsHandler(IStandingsReadRepository repository)
    : IQueryHandler<GetAllGroupStandingsQuery, IEnumerable<GroupStandingsDto>>
{
    public async Task<IEnumerable<GroupStandingsDto>> HandleAsync(
        GetAllGroupStandingsQuery query, CancellationToken ct)
    {
        var all = await repository.GetAllAsync(ct);
        return all
            .GroupBy(s => s.GroupName)
            .OrderBy(g => g.Key)
            .Select(g => new GroupStandingsDto
            {
                GroupName = g.Key,
                Standings = g
                    .OrderByDescending(s => s.Points)
                    .ThenByDescending(s => s.GoalsFor - s.GoalsAgainst)
                    .ThenByDescending(s => s.GoalsFor)
                    .Select(s => s.ToDto())
            });
    }
}
```

---

### Step 9: Create the standings DTOs

- [ ] Create `Application/DTOs/TeamStandingDto.cs`

```csharp
// Application/DTOs/TeamStandingDto.cs
namespace Goalkeeper.Server.Application.DTOs;

public class TeamStandingDto
{
    public string Group { get; set; } = string.Empty;
    public string Team { get; set; } = string.Empty;
    public string Flag { get; set; } = string.Empty;
    public int Played { get; set; }
    public int Won { get; set; }
    public int Drawn { get; set; }
    public int Lost { get; set; }
    public int Gf { get; set; }
    public int Ga { get; set; }
    public int Points { get; set; }
    public int? Possession { get; set; }
    public int? Defense { get; set; }
    public int? Attack { get; set; }
    public int? Passing { get; set; }
    public int? Pressing { get; set; }
}
```

- [ ] Create `Application/DTOs/GroupStandingsDto.cs`

```csharp
// Application/DTOs/GroupStandingsDto.cs
namespace Goalkeeper.Server.Application.DTOs;

public class GroupStandingsDto
{
    public string GroupName { get; set; } = string.Empty;
    public IEnumerable<TeamStandingDto> Standings { get; set; } = [];
}
```

---

### Step 10: Create the standings mapping extension

- [ ] Create `Application/DTOs/Mappers/StandingsMappingExtensions.cs`

```csharp
// Application/DTOs/Mappers/StandingsMappingExtensions.cs
using Goalkeeper.Server.Core.ReadModels;

namespace Goalkeeper.Server.Application.DTOs.Mappers;

public static class StandingsMappingExtensions
{
    public static TeamStandingDto ToDto(this TeamStandingReadModel model) => new()
    {
        Group = model.GroupName,
        Team = model.TeamName,
        Flag = model.TeamFlag,
        Played = model.Played,
        Won = model.Won,
        Drawn = model.Drawn,
        Lost = model.Lost,
        Gf = model.GoalsFor,
        Ga = model.GoalsAgainst,
        Points = model.Points,
        Possession = model.Possession,
        Defense = model.Defense,
        Attack = model.Attack,
        Passing = model.Passing,
        Pressing = model.Pressing,
    };
}
```

---

## Phase 4 — Application Layer: Commands

### Step 11: Create `RecordMatchResultCommand` and its handler

The handler is intentionally thin. It delegates domain logic to the aggregate and sync logic to the service — respecting SRP.

- [ ] Create folder `Application/Commands/RecordMatchResult/`
- [ ] Create `Application/Commands/RecordMatchResult/RecordMatchResultCommand.cs`

```csharp
// Application/Commands/RecordMatchResult/RecordMatchResultCommand.cs
namespace Goalkeeper.Server.Application.Commands.RecordMatchResult;

public record RecordMatchResultCommand(int MatchId, int HomeScore, int AwayScore);
```

- [ ] Create `Application/Commands/RecordMatchResult/RecordMatchResultHandler.cs`

```csharp
// Application/Commands/RecordMatchResult/RecordMatchResultHandler.cs
using Goalkeeper.Server.Application.Abstractions;
using Goalkeeper.Server.Infrastructure.Repositories;
using Goalkeeper.Server.Infrastructure.Services;

namespace Goalkeeper.Server.Application.Commands.RecordMatchResult;

public class RecordMatchResultHandler(
    IMatchRepository matchRepository,
    IStandingsSyncService standingsSyncService) : ICommandHandler<RecordMatchResultCommand>
{
    public async Task HandleAsync(RecordMatchResultCommand command, CancellationToken ct)
    {
        var match = await matchRepository.GetByIdAsync(command.MatchId, ct)
            ?? throw new KeyNotFoundException($"Match {command.MatchId} not found.");

        match.RecordResult(command.HomeScore, command.AwayScore);

        await matchRepository.SaveAsync(ct);

        // Update read model synchronously — standings are consistent by end of this request
        await standingsSyncService.RecalculateGroupAsync(match.GroupName, ct);
    }
}
```

---

## Phase 5 — Infrastructure Layer

### Step 12: Create `IStandingsReadRepository`

- [ ] Create `Infrastructure/Repositories/IStandingsReadRepository.cs`

```csharp
// Infrastructure/Repositories/IStandingsReadRepository.cs
using Goalkeeper.Server.Core.ReadModels;

namespace Goalkeeper.Server.Infrastructure.Repositories;

public interface IStandingsReadRepository
{
    Task<IEnumerable<TeamStandingReadModel>> GetByGroupAsync(string groupName, CancellationToken ct);
    Task<IEnumerable<TeamStandingReadModel>> GetAllAsync(CancellationToken ct);
}
```

---

### Step 13: Create `StandingsReadRepository`

- [ ] Create `Infrastructure/Repositories/StandingsReadRepository.cs`

```csharp
// Infrastructure/Repositories/StandingsReadRepository.cs
using Goalkeeper.Server.Core.ReadModels;
using Goalkeeper.Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Goalkeeper.Server.Infrastructure.Repositories;

public class StandingsReadRepository(GoalkeeperDbContext context) : IStandingsReadRepository
{
    public async Task<IEnumerable<TeamStandingReadModel>> GetByGroupAsync(string groupName, CancellationToken ct)
        => await context.TeamStandings
            .Where(s => s.GroupName == groupName)
            .ToListAsync(ct);

    public async Task<IEnumerable<TeamStandingReadModel>> GetAllAsync(CancellationToken ct)
        => await context.TeamStandings.ToListAsync(ct);
}
```

---

### Step 14: Create `IMatchRepository`

- [ ] Create `Infrastructure/Repositories/IMatchRepository.cs`

```csharp
// Infrastructure/Repositories/IMatchRepository.cs
using Goalkeeper.Server.Core.Aggregates;

namespace Goalkeeper.Server.Infrastructure.Repositories;

public interface IMatchRepository
{
    Task<Match?> GetByIdAsync(int id, CancellationToken ct);
    Task<IEnumerable<Match>> GetByGroupAsync(string groupName, CancellationToken ct);
    Task SaveAsync(CancellationToken ct);
}
```

---

### Step 15: Create `MatchRepository`

- [ ] Create `Infrastructure/Repositories/MatchRepository.cs`

```csharp
// Infrastructure/Repositories/MatchRepository.cs
using Goalkeeper.Server.Core.Aggregates;
using Goalkeeper.Server.Core.Enums;
using Goalkeeper.Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Goalkeeper.Server.Infrastructure.Repositories;

public class MatchRepository(GoalkeeperDbContext context) : IMatchRepository
{
    public async Task<Match?> GetByIdAsync(int id, CancellationToken ct)
        => await context.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .FirstOrDefaultAsync(m => m.Id == id, ct);

    public async Task<IEnumerable<Match>> GetByGroupAsync(string groupName, CancellationToken ct)
        => await context.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .Where(m => m.GroupName == groupName && m.Status == MatchStatus.Completed)
            .ToListAsync(ct);

    public async Task SaveAsync(CancellationToken ct)
        => await context.SaveChangesAsync(ct);
}
```

---

### Step 16: Create `IStandingsSyncService` and `StandingsSyncService`

- [ ] Create folder `Infrastructure/Services/`
- [ ] Create `Infrastructure/Services/IStandingsSyncService.cs`

```csharp
// Infrastructure/Services/IStandingsSyncService.cs
namespace Goalkeeper.Server.Infrastructure.Services;

public interface IStandingsSyncService
{
    Task RecalculateGroupAsync(string groupName, CancellationToken ct);
}
```

- [ ] Create `Infrastructure/Services/StandingsSyncService.cs`

This service owns all standings calculation logic. It reads every completed match in a group, tallies stats using the `StandingStats` value object, then replaces the read model rows atomically.

```csharp
// Infrastructure/Services/StandingsSyncService.cs
using Goalkeeper.Server.Core.ReadModels;
using Goalkeeper.Server.Core.ValueObjects;
using Goalkeeper.Server.Infrastructure.Data;
using Goalkeeper.Server.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Goalkeeper.Server.Infrastructure.Services;

public class StandingsSyncService(
    IMatchRepository matchRepository,
    GoalkeeperDbContext context) : IStandingsSyncService
{
    public async Task RecalculateGroupAsync(string groupName, CancellationToken ct)
    {
        var completedMatches = await matchRepository.GetByGroupAsync(groupName, ct);

        var statsMap = new Dictionary<int, (string Name, string Flag, StandingStats Stats)>();

        foreach (var match in completedMatches)
        {
            if (match.HomeScore is null || match.AwayScore is null) continue;

            var h = match.HomeScore.Value;
            var a = match.AwayScore.Value;

            Ensure(statsMap, match.HomeTeamId, match.HomeTeam!.Name, match.HomeTeam.Flag);
            Ensure(statsMap, match.AwayTeamId, match.AwayTeam!.Name, match.AwayTeam.Flag);

            var (homeName, homeFlag, homeStats) = statsMap[match.HomeTeamId];
            var (awayName, awayFlag, awayStats) = statsMap[match.AwayTeamId];

            if (h > a)
            {
                statsMap[match.HomeTeamId] = (homeName, homeFlag, homeStats.AddWin(h, a));
                statsMap[match.AwayTeamId] = (awayName, awayFlag, awayStats.AddLoss(a, h));
            }
            else if (h == a)
            {
                statsMap[match.HomeTeamId] = (homeName, homeFlag, homeStats.AddDraw(h, a));
                statsMap[match.AwayTeamId] = (awayName, awayFlag, awayStats.AddDraw(a, h));
            }
            else
            {
                statsMap[match.HomeTeamId] = (homeName, homeFlag, homeStats.AddLoss(h, a));
                statsMap[match.AwayTeamId] = (awayName, awayFlag, awayStats.AddWin(a, h));
            }
        }

        // Replace all rows for this group atomically
        var existing = await context.TeamStandings
            .Where(s => s.GroupName == groupName)
            .ToListAsync(ct);
        context.TeamStandings.RemoveRange(existing);

        context.TeamStandings.AddRange(statsMap.Select(kv => new TeamStandingReadModel
        {
            GroupName = groupName,
            TeamId = kv.Key,
            TeamName = kv.Value.Name,
            TeamFlag = kv.Value.Flag,
            Played = kv.Value.Stats.Played,
            Won = kv.Value.Stats.Won,
            Drawn = kv.Value.Stats.Drawn,
            Lost = kv.Value.Stats.Lost,
            GoalsFor = kv.Value.Stats.GoalsFor,
            GoalsAgainst = kv.Value.Stats.GoalsAgainst,
            Points = kv.Value.Stats.Points
        }));

        await context.SaveChangesAsync(ct);
    }

    private static void Ensure(
        Dictionary<int, (string Name, string Flag, StandingStats Stats)> map,
        int teamId, string name, string flag)
    {
        if (!map.ContainsKey(teamId))
            map[teamId] = (name, flag, StandingStats.Zero);
    }
}
```

---

### Step 17: Update `GoalkeeperDbContext`

- [ ] Open `Infrastructure/Data/GoalkeeperDbContext.cs`
- [ ] Add `DbSet<Match>` and `DbSet<TeamStandingReadModel>`
- [ ] Add `OnModelCreating` to configure relationships and the unique index on standings

```csharp
// Infrastructure/Data/GoalkeeperDbContext.cs
using Goalkeeper.Server.Core;
using Goalkeeper.Server.Core.Aggregates;
using Goalkeeper.Server.Core.ReadModels;

namespace Goalkeeper.Server.Infrastructure.Data;

public class GoalkeeperDbContext(DbContextOptions<GoalkeeperDbContext> options) : DbContext(options)
{
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Match> Matches => Set<Match>();
    public DbSet<TeamStandingReadModel> TeamStandings => Set<TeamStandingReadModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(m => m.Id);
            entity.HasOne(m => m.HomeTeam)
                  .WithMany()
                  .HasForeignKey(m => m.HomeTeamId)
                  .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(m => m.AwayTeam)
                  .WithMany()
                  .HasForeignKey(m => m.AwayTeamId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TeamStandingReadModel>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.HasIndex(s => new { s.GroupName, s.TeamId }).IsUnique();
        });
    }
}
```

---

### Step 18: Add the EF Core migration

- [ ] Run these commands from the `Goalkeeper.Server` directory:

```bash
dotnet ef migrations add AddMatchesAndStandings
```

> The migration runs automatically at startup via `db.Database.MigrateAsync()` already present in `Program.cs` — no manual `database update` needed in development.

---

## Phase 6 — Wire Up

### Step 19: Create `StandingsController`

Controllers inject handlers directly by their interface — no mediator involved.

- [ ] Create `Application/Controllers/StandingsController.cs`

```csharp
// Application/Controllers/StandingsController.cs
using Goalkeeper.Server.Application.Abstractions;
using Goalkeeper.Server.Application.Commands.RecordMatchResult;
using Goalkeeper.Server.Application.DTOs;
using Goalkeeper.Server.Application.Queries.GetAllGroupStandings;
using Goalkeeper.Server.Application.Queries.GetGroupStandings;
using Microsoft.AspNetCore.Mvc;

namespace Goalkeeper.Server.Application.Controllers;

[ApiController]
[Route("api/standings")]
[Produces("application/json")]
public class StandingsController(
    IQueryHandler<GetAllGroupStandingsQuery, IEnumerable<GroupStandingsDto>> getAllHandler,
    IQueryHandler<GetGroupStandingsQuery, IEnumerable<TeamStandingDto>> getGroupHandler,
    ICommandHandler<RecordMatchResultCommand> recordResultHandler,
    ILogger<StandingsController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        logger.LogDebug("GET /api/standings");
        var result = await getAllHandler.HandleAsync(new GetAllGroupStandingsQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{group}")]
    public async Task<IActionResult> GetByGroup(string group, CancellationToken cancellationToken)
    {
        logger.LogDebug("GET /api/standings/{Group}", group);
        var result = await getGroupHandler.HandleAsync(new GetGroupStandingsQuery(group.ToUpperInvariant()), cancellationToken);
        return Ok(result);
    }

    [HttpPost("~/api/matches/{matchId:int}/result")]
    public async Task<IActionResult> RecordResult(
        int matchId,
        [FromBody] RecordResultRequest request,
        CancellationToken cancellationToken)
    {
        await recordResultHandler.HandleAsync(
            new RecordMatchResultCommand(matchId, request.HomeScore, request.AwayScore),
            cancellationToken);
        return NoContent();
    }
}

public record RecordResultRequest(int HomeScore, int AwayScore);
```

---

### Step 20: Register services in `Program.cs`

- [ ] Open `Program.cs`
- [ ] Add the new repository, service, and handler registrations after the existing `AddScoped<ITeamsRepository, TeamsRepository>()` line:

```csharp
// Repositories
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<IStandingsReadRepository, StandingsReadRepository>();

// Services
builder.Services.AddScoped<IStandingsSyncService, StandingsSyncService>();

// Query handlers
builder.Services.AddScoped<
    IQueryHandler<GetAllGroupStandingsQuery, IEnumerable<GroupStandingsDto>>,
    GetAllGroupStandingsHandler>();
builder.Services.AddScoped<
    IQueryHandler<GetGroupStandingsQuery, IEnumerable<TeamStandingDto>>,
    GetGroupStandingsHandler>();

// Command handlers
builder.Services.AddScoped<
    ICommandHandler<RecordMatchResultCommand>,
    RecordMatchResultHandler>();
```

> Add the necessary `using` statements for the new namespaces.

---

## Phase 7 — Seed Data

### Step 21: Update `DbSeeder` with flags and group assignments

- [ ] Open `Infrastructure/Data/DbSeeder.cs`
- [ ] Replace the `string[]` team names with a tuple array that includes `Flag` and `Group`:

```csharp
// Add to DbSeeder.cs
private static readonly (string Name, string Flag, string Group)[] Teams =
[
    ("Mexico",        "🇲🇽", "A"), ("Morocco",     "🇲🇦", "A"), ("Ecuador",    "🇪🇨", "A"), ("Saudi Arabia", "🇸🇦", "A"),
    ("Spain",         "🇪🇸", "B"), ("Belgium",     "🇧🇪", "B"), ("Canada",     "🇨🇦", "B"), ("Portugal",    "🇵🇹", "B"),
    ("England",       "🏴󠁧󠁢󠁥󠁮󠁧󠁿", "C"), ("USA",         "🇺🇸", "C"), ("Senegal",    "🇸🇳", "C"), ("Iran",        "🇮🇷", "C"),
    ("Brazil",        "🇧🇷", "D"), ("France",      "🇫🇷", "D"), ("Japan",      "🇯🇵", "D"), ("Argentina",   "🇦🇷", "D"),
    ("Germany",       "🇩🇪", "E"), ("Netherlands", "🇳🇱", "E"), ("Italy",      "🇮🇹", "E"), ("Uruguay",     "🇺🇾", "E"),
    ("Croatia",       "🇭🇷", "F"), ("Ghana",       "🇬🇭", "F"), ("New Zealand","🇳🇿", "F"), ("Panama",      "🇵🇦", "F"),
    ("Egypt",         "🇪🇬", "G"), ("Colombia",    "🇨🇴", "G"), ("Ivory Coast","🇨🇮", "G"), ("Senegal",     "🇸🇳", "G"),
    ("Cape Verde",    "🇨🇻", "H"), ("Saudi Arabia","🇸🇦", "H"), ("Uruguay",    "🇺🇾", "H"), ("DR Congo",    "🇨🇩", "H"),
];
```

- [ ] Update `SeedTeamsAsync` to set `Flag` from the tuple
- [ ] Add a new `SeedMatchesAsync(GoalkeeperDbContext context)` method that creates a set of completed group-stage matches with realistic scores, matching the hardcoded data in `Dashboard.tsx`

---

### Step 22: Call the match seeder and trigger initial standings calculation in `Program.cs`

- [ ] Add inside the existing seeding block in `Program.cs`:

```csharp
await using (var scope = app.Services.CreateAsyncScope())
{
    var db = scope.ServiceProvider.GetRequiredService<GoalkeeperDbContext>();
    await db.Database.MigrateAsync();
    await DbSeeder.SeedTeamsAsync(db);
    await DbSeeder.SeedMatchesAsync(db);  // ← new

    // Build initial read model from seeded matches
    var syncService = scope.ServiceProvider.GetRequiredService<IStandingsSyncService>();
    foreach (var group in new[] { "A", "B", "C", "D", "E", "F", "G", "H" })
        await syncService.RecalculateGroupAsync(group, CancellationToken.None);
}
```

---

## Phase 8 — Frontend Integration

### Step 23: Create standings types

- [ ] Create `frontend/src/types/standings.ts`

```typescript
// frontend/src/types/standings.ts
export type TeamStandingDto = {
  group: string;
  team: string;
  flag: string;
  played: number;
  won: number;
  drawn: number;
  lost: number;
  gf: number;
  ga: number;
  points: number;
  possession?: number;
  defense?: number;
  attack?: number;
  passing?: number;
  pressing?: number;
};

export type GroupStandingsDto = {
  groupName: string;
  standings: TeamStandingDto[];
};
```

---

### Step 24: Create the `useStandings` hook

- [ ] Create `frontend/src/hooks/useStandings.ts`

```typescript
// frontend/src/hooks/useStandings.ts
import { useEffect, useState } from "react";
import type { GroupStandingsDto } from "../types/standings";

export function useStandings() {
  const [data, setData] = useState<GroupStandingsDto[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    fetch("/api/standings")
      .then((r) => {
        if (!r.ok) throw new Error(r.statusText);
        return r.json() as Promise<GroupStandingsDto[]>;
      })
      .then(setData)
      .catch(() => setError("Failed to load standings"))
      .finally(() => setLoading(false));
  }, []);

  return { data, loading, error };
}
```

---

### Step 25: Update `Dashboard.tsx` to consume the API

- [ ] Open `frontend/src/features/Dashboard.tsx`
- [ ] Import `useStandings` and the new types, remove the import of the hardcoded `STANDINGS` constant
- [ ] Replace the `useMemo` that derives groups from `STANDINGS`:

```typescript
// Remove:
// const groups = useMemo(() => {
//   const map: Record<string, TeamStanding[]> = {};
//   for (const s of STANDINGS) (map[s.group] ||= []).push(s);
//   return Object.entries(map);
// }, []);

// Add:
const { data: groupStandings, loading: standingsLoading } = useStandings();
```

- [ ] Update `GroupTable` props: rename `rows: TeamStanding[]` to `rows: TeamStandingDto[]` and add `groupName: string`
- [ ] Update the JSX that renders group tables:

```tsx
{/* Replace: */}
{groups.map(([g, rows]) => <GroupTable key={g} rows={rows} />)}

{/* With: */}
{standingsLoading
  ? <div className="col-span-2 text-muted-foreground text-sm">Loading standings…</div>
  : groupStandings.map((g) => (
      <GroupTable key={g.groupName} groupName={g.groupName} rows={g.standings} />
    ))
}
```

---

## Verification Checklist

Once all steps are complete, verify end-to-end:

- [ ] `dotnet run --project Goalkeeper.AppHost` starts without errors
- [ ] `GET /api/standings` returns an array of `GroupStandingsDto` objects
- [ ] `GET /api/standings/A` returns 4 rows sorted by points descending
- [ ] `POST /api/matches/{id}/result` with `{ "homeScore": 2, "awayScore": 1 }` updates standings on subsequent GET
- [ ] Dashboard renders live standings from the API (no hardcoded data)
- [ ] Swagger UI at `/openapi/v1.json` documents all three endpoints

---

## File Structure Summary

```
Goalkeeper.Server/
├── Core/
│   ├── Aggregates/
│   │   └── Match.cs                              ← new
│   ├── Enums/
│   │   └── MatchStatus.cs                        ← new
│   ├── ReadModels/
│   │   └── TeamStandingReadModel.cs              ← new
│   ├── ValueObjects/
│   │   └── StandingStats.cs                      ← new
│   ├── Fixture.cs                                ← existing (kept for reference)
│   └── Team.cs                                   ← updated (Flag added)
├── Application/
│   ├── Abstractions/
│   │   ├── ICommandHandler.cs                    ← new
│   │   └── IQueryHandler.cs                      ← new
│   ├── Commands/
│   │   └── RecordMatchResult/
│   │       ├── RecordMatchResultCommand.cs       ← new
│   │       └── RecordMatchResultHandler.cs       ← new
│   ├── Controllers/
│   │   └── StandingsController.cs                ← new
│   ├── DTOs/
│   │   ├── GroupStandingsDto.cs                  ← new
│   │   ├── TeamStandingDto.cs                    ← new
│   │   └── Mappers/
│   │       └── StandingsMappingExtensions.cs     ← new
│   └── Queries/
│       ├── GetAllGroupStandings/
│       │   ├── GetAllGroupStandingsQuery.cs      ← new
│       │   └── GetAllGroupStandingsHandler.cs    ← new
│       └── GetGroupStandings/
│           ├── GetGroupStandingsQuery.cs          ← new
│           └── GetGroupStandingsHandler.cs        ← new
├── Infrastructure/
│   ├── Data/
│   │   ├── DbSeeder.cs                           ← updated
│   │   ├── GoalkeeperDbContext.cs                ← updated
│   │   └── Migrations/                           ← new migration added
│   ├── Repositories/
│   │   ├── IMatchRepository.cs                   ← new
│   │   ├── IStandingsReadRepository.cs           ← new
│   │   ├── MatchRepository.cs                    ← new
│   │   └── StandingsReadRepository.cs            ← new
│   └── Services/
│       ├── IStandingsSyncService.cs              ← new
│       └── StandingsSyncService.cs               ← new
└── Program.cs                                    ← updated (new registrations)

frontend/src/
├── hooks/
│   └── useStandings.ts                           ← new
├── types/
│   └── standings.ts                              ← new
└── features/
    └── Dashboard.tsx                              ← updated
```
