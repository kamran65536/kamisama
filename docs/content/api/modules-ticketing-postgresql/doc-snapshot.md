---
last-checked-utc: 2026-08-15T00:46:32Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.Ticketing.TicketingPostgresqlDbContextBuilderExtensions
---

# Documentation Snapshot

The package description, complete public XML summaries, provider key, Core callback, context and migration behavior, process-wide switches, publication mismatch, useful context example, migration exclusion, and exact extension exemption were reviewed against current source at the recorded root version.

## Description

PostgreSQL EF Core context and provider registration for KamiSama.Modules.Ticketing.Core, including Ticketing migrations and keyed context resolution.
Select it from the Core provider callback when the configured database provider is `postgresql`.

## How to use

**Publication mismatch:** `10.0.0` below is the current workspace/root documentation version and remains required in repository documentation. NuGet exposed `10.0.11` as the latest provider package when reviewed; `10.0.0` itself was not available.

```shell
dotnet add package KamiSama.Modules.Ticketing.Postgresql --version 10.0.0
```

Pass `database => database.AddPostgresqlTicketingDbContext()` to `AddTicketingModule` and configure provider `postgresql`. Registration adds `PostgresqlTicketingDbContext` under the exact keyed base-context service, enables lazy-loading proxies, uses `__EFMigrationsHistory_Ticketing`, and applies the shared PostgreSQL registration's process-wide legacy timestamp and infinity-conversion switches.

The V1_0_0 migration creates category, ticket, comment, and attachment tables, required cascade relationships, relationship indexes, integer enums, and 50/100/400 character limits. Core can apply pending migrations during `BuildAsync`, so startup needs a reachable PostgreSQL database and migration privileges.

## Example decisions

`PostgresqlTicketingDbContext` has an exact-full-name setup example. Static `TicketingPostgresqlDbContextBuilderExtensions` is exempt because the How-to and exact `AddPostgresqlTicketingDbContext` member example cover its only operation. Migration and generated model-snapshot files are intentionally excluded from generated public API pages.
