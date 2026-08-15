# KamiSama.Repositories.EntityFrameworkCore

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Entity Framework Core repositories, paging, database initialization, and multi-provider DbContext registration. Use it for tracked repository access, migration and seed workflows, or configuration-selected provider contexts.

## How to use

```shell
dotnet add package KamiSama.Repositories.EntityFrameworkCore --version 10.0.0
```

Register the base context from configuration, set one shared migration-history table, and add each installed concrete provider context through its generic extension:

```csharp
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Postgresql;
using KamiSama.Repositories.EntityFrameworkCore.Sqlite;

services.AddMultiProviderDbContext<AppDbContext>(configuration.GetSection("Database"))
    .WithMigrationHistoryTable("__AppMigrationsHistory")
    .AddPostgresql<PostgresqlAppDbContext>()
    .AddSqlite<SqliteAppDbContext>();
```

Configuration uses the `provider` and `connection-string` keys. Provider lookup lowercases the configured value, and installed providers register exact `postgresql` or `sqlite` keys. Contexts and the keyed base-context alias are scoped. Provider packages enable lazy-loading proxies and apply the configured migration-history table.

`DbRepository<TEntity>` borrows its context, does not dispose it, tracks queries by default, and saves every mutation immediately. `MakePagedAsync<T>` requires caller-supplied deterministic ordering, counts synchronously without cancellation, then materializes asynchronously in a separate query. Initializer stages run sequentially without a transaction supplied by the base class.

## Namespaces

- [KamiSama.Repositories.EntityFrameworkCore](kamisama-repositories-entityframeworkcore/index.md) (6 types)
- [KamiSama.Repositories.EntityFrameworkCore.Initialization](kamisama-repositories-entityframeworkcore-initialization/index.md) (2 types)

## Types

- [KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity, TDbContext>](kamisama-repositories-entityframeworkcore/kamisama-repositories-entityframeworkcore-dbrepository-tentity-tdbcontext/index.md) - EF Core repository over a borrowed `DbContext`. Queries track by default, every mutation saves immediately, and repository disposal does not dispose the context.
- [KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>](kamisama-repositories-entityframeworkcore/kamisama-repositories-entityframeworkcore-dbrepository-tentity/index.md) - EF Core repository over a borrowed `DbContext`. Queries track by default, every mutation saves immediately, and repository disposal does not dispose the context.
- [KamiSama.Repositories.EntityFrameworkCore.IMultiProviderDbContextBuilder](kamisama-repositories-entityframeworkcore/kamisama-repositories-entityframeworkcore-imultiproviderdbcontextbuilder/index.md) - Carries the services, configuration-selected provider, base context type, and migration-history table used by concrete provider registration extensions.
- [KamiSama.Repositories.EntityFrameworkCore.IMultiProviderDbContextBuilder<TBaseContext>](kamisama-repositories-entityframeworkcore/kamisama-repositories-entityframeworkcore-imultiproviderdbcontextbuilder-tbasecontext/index.md) - Carries the services, configuration-selected provider, base context type, and migration-history table used by concrete provider registration extensions.
- [KamiSama.Repositories.EntityFrameworkCore.IQueryableExtensions](kamisama-repositories-entityframeworkcore/kamisama-repositories-entityframeworkcore-iqueryableextensions/index.md) - Pages EF Core queries using caller-supplied ordering. It synchronously counts all matches before cancellable asynchronous materialization, using two separate database queries.
- [KamiSama.Repositories.EntityFrameworkCore.ServiceCollectionExtensions](kamisama-repositories-entityframeworkcore/kamisama-repositories-entityframeworkcore-servicecollectionextensions/index.md) - Binds `provider` and `connection-string`, then adds scoped keyed resolution for an application-facing base context. Concrete provider packages must register the lowercased configured key.
- [KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>](kamisama-repositories-entityframeworkcore-initialization/kamisama-repositories-entityframeworkcore-initialization-databaseinitializerbase-tdbcontext/index.md) - Runs selected migration, application-data, and test-data stages sequentially for an EF Core context. Derived initializers implement both seed hooks and can use `TryAdd` for immediate conditional persistence.
- [KamiSama.Repositories.EntityFrameworkCore.Initialization.DefaultDatabaseInitializer<TDbContext>](kamisama-repositories-entityframeworkcore-initialization/kamisama-repositories-entityframeworkcore-initialization-defaultdatabaseinitializer-tdbcontext/index.md) - Migration-only EF Core initializer. Migration runs when selected, while application-data and test-data stages complete without performing work.
