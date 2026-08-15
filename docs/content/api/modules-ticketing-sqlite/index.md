# KamiSama.Modules.Ticketing.Sqlite

[Back to package index](../index.md)

Version: `10.0.0`

## Description

SQLite EF Core context and provider registration for KamiSama.Modules.Ticketing.Core, including Ticketing migrations and keyed context resolution. Select it from the Core provider callback when the configured database provider is `sqlite`.

## How to use

```shell
dotnet add package KamiSama.Modules.Ticketing.Sqlite --version 10.0.0
```

**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet exposed `10.0.11` as the latest provider package when reviewed; `10.0.0` itself was not available.

Install this package with Ticketing Core, configure the database provider as `sqlite`, and pass `database => database.AddSqliteTicketingDbContext()` to `AddTicketingModule`. The callback registers `SqliteTicketingDbContext` under the exact `sqlite` key, enables lazy-loading proxies, uses `__EFMigrationsHistory_Ticketing`, and supplies a V1_0_0 migration that creates the four Ticketing tables and cascading relationships. `BuildAsync` can apply it during startup, so the process needs write access to the SQLite database file and its directory.

## Namespaces

- [KamiSama.Modules.Ticketing](kamisama-modules-ticketing/index.md) (1 types)
- [KamiSama.Modules.Ticketing.Repositories.Database.Sqlite](kamisama-modules-ticketing-repositories-database-sqlite/index.md) (1 types)

## Types

- [KamiSama.Modules.Ticketing.TicketingSqliteDbContextBuilderExtensions](kamisama-modules-ticketing/kamisama-modules-ticketing-ticketingsqlitedbcontextbuilderextensions/index.md) - Registers the SQLite Ticketing context under the exact `sqlite` keyed base-context service. Use it from the callback passed to `AddTicketingModule`.
- [KamiSama.Modules.Ticketing.Repositories.Database.Sqlite.SqliteTicketingDbContext](kamisama-modules-ticketing-repositories-database-sqlite/kamisama-modules-ticketing-repositories-database-sqlite-sqliteticketingdbcontext/index.md) - Concrete SQLite Ticketing context targeted by this provider package's migrations. Normal hosts register it through `AddSqliteTicketingDbContext` rather than constructing it directly.
