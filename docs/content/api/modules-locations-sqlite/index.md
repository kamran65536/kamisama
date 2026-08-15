# KamiSama.Modules.Locations.Sqlite

[Back to package index](../index.md)

Version: `10.0.0`

## Description

SQLite EF Core context and provider registration for KamiSama.Modules.Locations.Core, including Locations migrations and keyed context resolution. Select it from the Core provider callback when the configured database provider is `sqlite`.

## How to use

```shell
dotnet add package KamiSama.Modules.Locations.Sqlite --version 10.0.0
```

**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet exposed `10.0.11` as the latest provider package when reviewed; `10.0.0` itself was not available.

Install this package with Locations Core, configure the database provider as `sqlite`, and pass `database => database.AddSqliteLocationsDbContext()` to `AddLocationsModule`. The callback registers `SqliteLocationsDbContext` under the exact `sqlite` key, enables lazy-loading proxies, uses `__EFMigrationsHistory_Locations`, and supplies this package's migrations. `BuildAsync` can apply pending migrations during startup, so the process needs write access to the SQLite database file and its directory.

## Namespaces

- [KamiSama.Modules.Locations](kamisama-modules-locations/index.md) (1 types)
- [KamiSama.Modules.Locations.Repositories.Database.Sqlite](kamisama-modules-locations-repositories-database-sqlite/index.md) (1 types)

## Types

- [KamiSama.Modules.Locations.LocationsSqliteDbContextBuilderExtensions](kamisama-modules-locations/kamisama-modules-locations-locationssqlitedbcontextbuilderextensions/index.md) - Registers the SQLite Locations context under the exact `sqlite` keyed base-context service. Use it from the callback passed to `AddLocationsModule`.
- [KamiSama.Modules.Locations.Repositories.Database.Sqlite.SqliteLocationsDbContext](kamisama-modules-locations-repositories-database-sqlite/kamisama-modules-locations-repositories-database-sqlite-sqlitelocationsdbcontext/index.md) - Concrete SQLite Locations context targeted by this provider package's migrations. Normal hosts register it through `AddSqliteLocationsDbContext` rather than constructing it directly.
