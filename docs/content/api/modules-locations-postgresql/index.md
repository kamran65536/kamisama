# KamiSama.Modules.Locations.Postgresql

[Back to package index](../index.md)

Version: `10.0.0`

## Description

PostgreSQL EF Core context and provider registration for KamiSama.Modules.Locations.Core, including Locations migrations and keyed context resolution. Select it from the Core provider callback when the configured database provider is `postgresql`.

## How to use

```shell
dotnet add package KamiSama.Modules.Locations.Postgresql --version 10.0.0
```

**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet exposed `10.0.11` as the latest provider package when reviewed; `10.0.0` itself was not available.

Install this package with Locations Core, configure the database provider as `postgresql`, and pass `database => database.AddPostgresqlLocationsDbContext()` to `AddLocationsModule`. The callback registers `PostgresqlLocationsDbContext` under the exact `postgresql` key, enables lazy-loading proxies, uses `__EFMigrationsHistory_Locations`, and supplies this package's migrations. `BuildAsync` can apply pending migrations during startup, so the PostgreSQL database must be reachable and the application principal needs migration privileges.

## Namespaces

- [KamiSama.Modules.Locations](kamisama-modules-locations/index.md) (1 types)
- [KamiSama.Modules.Locations.Repositories.Database.Postgresql](kamisama-modules-locations-repositories-database-postgresql/index.md) (1 types)

## Types

- [KamiSama.Modules.Locations.LocationsPostgresqlDbContextBuilderExtensions](kamisama-modules-locations/kamisama-modules-locations-locationspostgresqldbcontextbuilderextensions/index.md) - Registers the PostgreSQL Locations context under the exact `postgresql` keyed base-context service. Use it from the callback passed to `AddLocationsModule`.
- [KamiSama.Modules.Locations.Repositories.Database.Postgresql.PostgresqlLocationsDbContext](kamisama-modules-locations-repositories-database-postgresql/kamisama-modules-locations-repositories-database-postgresql-postgresqllocationsdbcontext/index.md) - Concrete PostgreSQL Locations context targeted by this provider package's migrations. Normal hosts register it through `AddPostgresqlLocationsDbContext` rather than constructing it directly.
