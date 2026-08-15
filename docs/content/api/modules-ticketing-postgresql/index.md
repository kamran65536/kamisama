# KamiSama.Modules.Ticketing.Postgresql

[Back to package index](../index.md)

Version: `10.0.0`

## Description

PostgreSQL EF Core context and provider registration for KamiSama.Modules.Ticketing.Core, including Ticketing migrations and keyed context resolution. Select it from the Core provider callback when the configured database provider is `postgresql`.

## How to use

```shell
dotnet add package KamiSama.Modules.Ticketing.Postgresql --version 10.0.0
```

**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet exposed `10.0.11` as the latest provider package when reviewed; `10.0.0` itself was not available.

Install this package with Ticketing Core, configure the database provider as `postgresql`, and pass `database => database.AddPostgresqlTicketingDbContext()` to `AddTicketingModule`. The callback registers `PostgresqlTicketingDbContext` under the exact `postgresql` key, enables lazy-loading proxies, uses `__EFMigrationsHistory_Ticketing`, and applies the shared PostgreSQL provider's process-wide legacy timestamp and infinity-conversion switches. Its V1_0_0 migration creates the four Ticketing tables and cascading relationships. `BuildAsync` can apply it during startup, so PostgreSQL must be reachable and the application principal needs migration privileges.

## Namespaces

- [KamiSama.Modules.Ticketing](kamisama-modules-ticketing/index.md) (1 types)
- [KamiSama.Modules.Ticketing.Repositories.Database.Postgresql](kamisama-modules-ticketing-repositories-database-postgresql/index.md) (1 types)

## Types

- [KamiSama.Modules.Ticketing.TicketingPostgresqlDbContextBuilderExtensions](kamisama-modules-ticketing/kamisama-modules-ticketing-ticketingpostgresqldbcontextbuilderextensions/index.md) - Registers the PostgreSQL Ticketing context under the exact `postgresql` keyed base-context service. Use it from the callback passed to `AddTicketingModule`.
- [KamiSama.Modules.Ticketing.Repositories.Database.Postgresql.PostgresqlTicketingDbContext](kamisama-modules-ticketing-repositories-database-postgresql/kamisama-modules-ticketing-repositories-database-postgresql-postgresqlticketingdbcontext/index.md) - Concrete PostgreSQL Ticketing context targeted by this provider package's migrations. Normal hosts register it through `AddPostgresqlTicketingDbContext` rather than constructing it directly.
