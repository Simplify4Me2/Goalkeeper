# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this is

Goalkeeper is a football/soccer statistics tracking portfolio project. It tracks match fixtures, player statistics, and team analytics.

## Commands

**Run the full stack (preferred):**
```bash
dotnet run --project Goalkeeper.AppHost
```
This starts the Aspire dashboard, SQL Server, the ASP.NET Core server, and the React frontend — all orchestrated together.

**Build the .NET solution:**
```bash
dotnet build Goalkeeper.slnx
```

**Frontend (standalone):**
```bash
cd frontend
npm install
npm run dev      # dev server with API proxy
npm run build    # tsc + vite build
npm run lint     # eslint
```

**Tests (legacy services):**
```bash
dotnet test 02.Services/<ServiceName>/<ServiceName>.sln
```

## Architecture

The codebase has two distinct layers:

### Active stack (`/Goalkeeper.AppHost`, `/Goalkeeper.Server`, `/frontend`)

**AppHost** (`Goalkeeper.AppHost/AppHost.cs`) orchestrates everything via .NET Aspire:
- Provisions SQL Server → `sqldb` database
- Starts `Goalkeeper.Server`, wired to the database, with a health check at `/health`
- Starts the Vite frontend, which waits for the server
- In production builds, publishes the compiled frontend into the server's `wwwroot`

**Goalkeeper.Server** is a single ASP.NET Core 10 project:
- `Extensions.cs` — shared Aspire service defaults: OpenTelemetry (metrics + tracing), health checks (`/health`, `/alive`), service discovery, HTTP resilience
- `Program.cs` — minimal hosting; calls `AddServiceDefaults()`, registers controllers, maps `/api` group, serves static files (SPA fallback)
- `Core/` — domain models (e.g., `Fixture`)
- `Application/Controllers/` — MVC controllers; `Application/DTOs/` — request/response shapes
- OpenAPI/Swagger available in development at `/openapi/v1.json`

**frontend** is a React 19 + TypeScript Vite app. During development, Vite proxies `/api` calls to the running server. In production the compiled output is embedded in the server's `wwwroot`.

### Legacy microservices (`/02.Services/`)

Four separate .NET services, each with their own solution file. These predate Aspire and use a layered Clean Architecture pattern (Domain → Application → Infrastructure → WebApi) with MediatR for CQRS and xUnit for testing. They are not wired into the Aspire AppHost yet.

- `GoalKeeper.MApi` — main fixture/match API
- `GoalKeeper.Stats` — statistics with event sourcing
- `GoalKeeper.DataCollector` — data ingestion
- `Analytics.MApi` — analytics queries

`run.cmd` in the root shows how to start Stats and DataCollector manually for local legacy development.

## Key relationships

- `Goalkeeper.Server` depends on `Extensions.cs` for all Aspire plumbing — do not duplicate health check or telemetry registration there.
- The AppHost `server.PublishWithContainerFiles(webfrontend, "wwwroot")` call is how the SPA ends up inside the server container at publish time; the Vite proxy is only for local dev.
- SQL Server connection string flows from AppHost → Server via Aspire service discovery; no manual connection string configuration is needed in development.
