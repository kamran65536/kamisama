# KamiSama.Repositories.EntityFrameworkCore.Sqlite

[Back to package index](../index.md)

Version: `10.0.0`

## Description

SQLite registration for KamiSama multi-provider Entity Framework Core DbContexts. It adds scoped keyed context resolution, lazy-loading proxies, and migration-history configuration.

## How to use

```shell
dotnet add package KamiSama.Repositories.EntityFrameworkCore.Sqlite --version 10.0.0
```

**Warning:** the workspace root version is `10.0.0`, but a matching provider package may not be published. The required workspace-version command above is intentionally retained.

Register a concrete context derived from the base context after `AddMultiProviderDbContext<TBaseContext>`: `builder.AddSqlite<SqliteAppDbContext>()`. This adds scoped services under the exact `sqlite` key, enables lazy-loading proxies, and applies the builder migration-history table.

## Namespaces

- [KamiSama.Repositories.EntityFrameworkCore.Sqlite](kamisama-repositories-entityframeworkcore-sqlite/index.md) (1 types)

## Types

- [KamiSama.Repositories.EntityFrameworkCore.Sqlite.MultiProviderDbContextBuilderSqliteExtensions](kamisama-repositories-entityframeworkcore-sqlite/kamisama-repositories-entityframeworkcore-sqlite-multiproviderdbcontextbuildersqliteextensions/index.md) - Registers a scoped SQLite context under the exact `sqlite` key, enables lazy-loading proxies, and configures the provider migration-history table.
