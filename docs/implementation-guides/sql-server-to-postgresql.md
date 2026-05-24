# Migration Guide: SQL Server → PostgreSQL

## Overview

This guide migrates the Aspire-orchestrated stack from SQL Server to PostgreSQL. Four files change: the AppHost project file, `AppHost.cs`, the Server project file, and `Program.cs`. The existing EF Core migration must be deleted and regenerated because it contains SQL Server-specific type annotations.

---

## Step 1 — Swap the AppHost hosting package

In `Goalkeeper.AppHost/Goalkeeper.AppHost.csproj`, replace the SQL Server hosting package with the PostgreSQL one. Keep the same Aspire version (`13.2.4`).

**Before:**
```xml
<PackageReference Include="Aspire.Hosting.SqlServer" Version="13.2.4" />
```

**After:**
```xml
<PackageReference Include="Aspire.Hosting.PostgreSql" Version="13.2.4" />
```

---

## Step 2 — Update AppHost.cs

In `Goalkeeper.AppHost/AppHost.cs`, replace the SQL Server resource with a PostgreSQL resource. The connection name `"goaldb"` is the key Aspire injects into the server as a connection string — it must match what you use in Step 4.

**Before:**
```csharp
var sql = builder.AddSqlServer("sql");
var sqldb = sql.AddDatabase("sqldb");

var server = builder.AddProject<Projects.Goalkeeper_Server>("server")
    .WaitFor(sqldb)
    .WithReference(sqldb)
    ...
```

**After:**
```csharp
var postgres = builder.AddPostgres("postgres");
var goaldb = postgres.AddDatabase("goaldb");

var server = builder.AddProject<Projects.Goalkeeper_Server>("server")
    .WaitFor(goaldb)
    .WithReference(goaldb)
    ...
```

> The rest of `AppHost.cs` (the `webfrontend` resource and `PublishWithContainerFiles`) is unchanged.

---

## Step 3 — Swap the Server EF Core package

In `Goalkeeper.Server/Goalkeeper.Server.csproj`, replace the Aspire SQL Server EF Core package with the Npgsql equivalent. Keep the same version.

**Before:**
```xml
<PackageReference Include="Aspire.Microsoft.EntityFrameworkCore.SqlServer" Version="13.2.4" />
```

**After:**
```xml
<PackageReference Include="Aspire.Npgsql.EntityFrameworkCore.PostgreSQL" Version="13.2.4" />
```

Then restore packages:
```bash
dotnet restore Goalkeeper.slnx
```

---

## Step 4 — Update Program.cs

In `Goalkeeper.Server/Program.cs`, replace the SQL Server DbContext registration with the Npgsql one. The string `"goaldb"` must match the database name from Step 2.

**Before:**
```csharp
builder.AddSqlServerDbContext<GoalkeeperDbContext>("sqldb");
```

**After:**
```csharp
builder.AddNpgsqlDbContext<GoalkeeperDbContext>("goaldb");
```

---

## Step 5 — Delete the existing migration

The current migration at `Goalkeeper.Server/Infrastructure/Data/Migrations/` contains SQL Server-specific type annotations (`nvarchar(max)`, `SqlServer:Identity`) that are invalid under the PostgreSQL provider. Delete all three files:

```
Infrastructure/Data/Migrations/20260502100335_InitialCreateTeams.cs
Infrastructure/Data/Migrations/20260502100335_InitialCreateTeams.Designer.cs
Infrastructure/Data/Migrations/GoalkeeperDbContextModelSnapshot.cs
```

---

## Step 6 — Recreate the migration for PostgreSQL

With the Npgsql provider now active, scaffold a fresh migration. Run this from the repo root:

```bash
dotnet ef migrations add InitialCreate \
  --project Goalkeeper.Server \
  --output-dir Infrastructure/Data/Migrations
```

The regenerated migration will use PostgreSQL types (`integer`, `text`) and the `Npgsql:ValueGenerationStrategy` annotation instead of the old SQL Server ones.

---

## Step 7 — Verify

Build the solution to confirm no compilation errors:

```bash
dotnet build Goalkeeper.slnx
```

Then run the full stack:

```bash
dotnet run --project Goalkeeper.AppHost
```

Aspire will pull the `postgres` Docker image, start the container, create the `goaldb` database, and apply the migration automatically via the `db.Database.MigrateAsync()` call in `Program.cs`. Open the Aspire dashboard to confirm the `postgres` resource shows as healthy before the server starts.
