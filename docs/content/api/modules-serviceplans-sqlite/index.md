# KamiSama.Modules.ServicePlans.Sqlite

[Back to package index](../index.md)

Version: `10.0.0`

## Description

SQLite EF Core context registration for ServicePlans Core under the `sqlite` provider key. It configures SQLite and lazy loading but currently ships no ServicePlans migrations.

## How to use

```shell
dotnet add package KamiSama.Modules.ServicePlans.Sqlite --version 10.0.0
```

**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet returned no published package or version for this package ID when reviewed.

Install this package with ServicePlans Core, configure provider `sqlite`, and pass `database => database.AddSqliteServicePlansDbContext()` to `AddServicePlansModule`. Registration adds a scoped SQLite context and exact keyed base-context alias, enables lazy-loading proxies, and uses `__EFMigrationsHistory_ServicePlans`. This package contains no ServicePlans migrations, so provision a compatible schema or supply migrations separately.

## Namespaces

- [KamiSama.Modules.ServicePlans](kamisama-modules-serviceplans/index.md) (1 types)
- [KamiSama.Modules.ServicePlans.Repositories.Database.Sqlite](kamisama-modules-serviceplans-repositories-database-sqlite/index.md) (1 types)

## Types

- [KamiSama.Modules.ServicePlans.ServicePlansSqliteDbContextBuilderExtensions](kamisama-modules-serviceplans/kamisama-modules-serviceplans-serviceplanssqlitedbcontextbuilderextensions/index.md) - Registers the SQLite ServicePlans context under the exact `sqlite` keyed base-context service. It enables lazy loading but supplies no migrations.
- [KamiSama.Modules.ServicePlans.Repositories.Database.Sqlite.SqliteServicePlansDbContext](kamisama-modules-serviceplans-repositories-database-sqlite/kamisama-modules-serviceplans-repositories-database-sqlite-sqliteserviceplansdbcontext/index.md) - Concrete SQLite ServicePlans context registered through `AddSqliteServicePlansDbContext`. Its provider package currently contains no migrations.
