# KamiSama.Modules.ServicePlans.Postgresql

[Back to package index](../index.md)

Version: `10.0.0`

## Description

PostgreSQL EF Core context registration for ServicePlans Core under the `postgresql` provider key. It configures Npgsql and lazy loading but currently ships no ServicePlans migrations.

## How to use

```shell
dotnet add package KamiSama.Modules.ServicePlans.Postgresql --version 10.0.0
```

**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet returned no published package or version for this package ID when reviewed.

Install this package with ServicePlans Core, configure provider `postgresql`, and pass `database => database.AddPostgresqlServicePlansDbContext()` to `AddServicePlansModule`. Registration adds a scoped Npgsql context and exact keyed base-context alias, enables lazy-loading proxies, uses `__EFMigrationsHistory_ServicePlans`, and applies the shared PostgreSQL provider's process-wide legacy timestamp and disabled infinity-conversion switches. This package contains no ServicePlans migrations, so provision a compatible schema or supply migrations separately.

## Namespaces

- [KamiSama.Modules.ServicePlans](kamisama-modules-serviceplans/index.md) (1 types)
- [KamiSama.Modules.ServicePlans.Repositories.Database.Postgresql](kamisama-modules-serviceplans-repositories-database-postgresql/index.md) (1 types)

## Types

- [KamiSama.Modules.ServicePlans.ServicePlansPostgresqlDbContextBuilderExtensions](kamisama-modules-serviceplans/kamisama-modules-serviceplans-serviceplanspostgresqldbcontextbuilderextensions/index.md) - Registers the PostgreSQL ServicePlans context under the exact `postgresql` keyed base-context service. It enables lazy loading and shared Npgsql switches but supplies no migrations.
- [KamiSama.Modules.ServicePlans.Repositories.Database.Postgresql.PostgresqlServicePlansDbContext](kamisama-modules-serviceplans-repositories-database-postgresql/kamisama-modules-serviceplans-repositories-database-postgresql-postgresqlserviceplansdbcontext/index.md) - Concrete PostgreSQL ServicePlans context registered through `AddPostgresqlServicePlansDbContext`. Its provider package currently contains no migrations.
