# KamiSama.Modules.PolicyEngine.Postgresql

[Back to package index](../index.md)

Version: `10.0.0`

## Description

PostgreSQL EF Core context registration for PolicyEngine Core under the `postgresql` provider key. It configures Npgsql and lazy loading but currently ships no PolicyEngine migrations.

## How to use

```shell
dotnet add package KamiSama.Modules.PolicyEngine.Postgresql --version 10.0.0
```

**Publication mismatch:** `10.0.0` is the current workspace/root documentation version and remains the required repository install command. NuGet returned no published package or version for this package ID when reviewed.

Install this package with PolicyEngine Core and call `database => database.AddPostgresqlPolicyEngineDbContext()` from `AddPolicyEngineModule` while the database provider value is `postgresql` (case-insensitive before keyed lookup). Registration adds a scoped Npgsql context, lazy-loading proxies, `__EFMigrationsHistory_PolicyEngine`, and process-wide legacy timestamp and disabled infinity-conversion switches. This package contains no PolicyEngine migrations, so startup migration does not create the module schema; provision a compatible schema or provide migrations separately.

## Namespaces

- [KamiSama.Modules.PolicyEngine](kamisama-modules-policyengine/index.md) (1 types)
- [KamiSama.Modules.PolicyEngine.Repositories.Database.Postgresql](kamisama-modules-policyengine-repositories-database-postgresql/index.md) (1 types)

## Types

- [KamiSama.Modules.PolicyEngine.PolicyEnginePostgresqlDbContextBuilderExtensions](kamisama-modules-policyengine/kamisama-modules-policyengine-policyenginepostgresqldbcontextbuilderextensions/index.md) - Registers the PostgreSQL PolicyEngine context under the exact `postgresql` keyed base-context service. It enables lazy loading and shared Npgsql switches but supplies no migrations.
- [KamiSama.Modules.PolicyEngine.Repositories.Database.Postgresql.PostgresqlPolicyEngineDbContext](kamisama-modules-policyengine-repositories-database-postgresql/kamisama-modules-policyengine-repositories-database-postgresql-postgresqlpolicyenginedbcontext/index.md) - Concrete PostgreSQL PolicyEngine context registered through `AddPostgresqlPolicyEngineDbContext`. Its provider package currently contains no migrations.
