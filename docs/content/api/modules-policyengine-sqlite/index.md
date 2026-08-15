# KamiSama.Modules.PolicyEngine.Sqlite

[Back to package index](../index.md)

Version: `10.0.0`

## Description

SQLite EF Core context registration for PolicyEngine Core under the `sqlite` provider key. It configures SQLite and lazy loading but currently ships no PolicyEngine migrations.

## How to use

```shell
dotnet add package KamiSama.Modules.PolicyEngine.Sqlite --version 10.0.0
```

**Publication mismatch:** `10.0.0` is the current workspace/root documentation version and remains the required repository install command. NuGet returned no published package or version for this package ID when reviewed.

Install this package with PolicyEngine Core and call `database => database.AddSqlitePolicyEngineDbContext()` from `AddPolicyEngineModule` while the database provider value is `sqlite` (case-insensitive before keyed lookup). Registration adds a scoped SQLite context, lazy-loading proxies, and `__EFMigrationsHistory_PolicyEngine`. This package contains no PolicyEngine migrations, so startup migration does not create the module schema; provision a compatible schema or provide migrations separately.

## Namespaces

- [KamiSama.Modules.PolicyEngine](kamisama-modules-policyengine/index.md) (1 types)
- [KamiSama.Modules.PolicyEngine.Repositories.Database.Sqlite](kamisama-modules-policyengine-repositories-database-sqlite/index.md) (1 types)

## Types

- [KamiSama.Modules.PolicyEngine.PolicyEngineSqliteDbContextBuilderExtensions](kamisama-modules-policyengine/kamisama-modules-policyengine-policyenginesqlitedbcontextbuilderextensions/index.md) - Registers the SQLite PolicyEngine context under the exact `sqlite` keyed base-context service. It enables lazy loading but supplies no migrations.
- [KamiSama.Modules.PolicyEngine.Repositories.Database.Sqlite.SqlitePolicyEngineDbContext](kamisama-modules-policyengine-repositories-database-sqlite/kamisama-modules-policyengine-repositories-database-sqlite-sqlitepolicyenginedbcontext/index.md) - Concrete SQLite PolicyEngine context registered through `AddSqlitePolicyEngineDbContext`. Its provider package currently contains no migrations.
