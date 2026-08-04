# KamiSama.Repositories.EntityFrameworkCore

[Back to package index](../index.md)

Version: `10.0.10`

## Description

Repository implementation, paging helpers, database initialization, and multi-provider DbContext registration for Entity Framework Core. Use it with the surrounding package APIs when composing application code.

## Install

```shell
dotnet add package KamiSama.Repositories.EntityFrameworkCore --version 10.0.10
```

## Namespaces

- [KamiSama.Repositories.EntityFrameworkCore](kamisama-repositories-entityframeworkcore/index.md) (7 types)
- [KamiSama.Repositories.EntityFrameworkCore.Initialization](kamisama-repositories-entityframeworkcore-initialization/index.md) (2 types)

## Types

- [KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity, TDbContext>](kamisama-repositories-entityframeworkcore/kamisama-repositories-entityframeworkcore-dbrepository-tentity-tdbcontext/index.md) - Repository wrapper around an EF DbContext. Use it when you want the standard KamiSama repository methods over a DbSet without writing the same CRUD code in each repository.
- [KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>](kamisama-repositories-entityframeworkcore/kamisama-repositories-entityframeworkcore-dbrepository-tentity/index.md) - Repository wrapper around an EF DbContext. Use it when you want the standard KamiSama repository methods over a DbSet without writing the same CRUD code in each repository.
- [KamiSama.Repositories.EntityFrameworkCore.IMultiProviderDbContextBuilder](kamisama-repositories-entityframeworkcore/kamisama-repositories-entityframeworkcore-imultiproviderdbcontextbuilder/index.md) - Defines the provider-neutral state needed to register a DbContext for multiple database providers. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Repositories.EntityFrameworkCore.IMultiProviderDbContextBuilder<TBaseContext>](kamisama-repositories-entityframeworkcore/kamisama-repositories-entityframeworkcore-imultiproviderdbcontextbuilder-tbasecontext/index.md) - Defines provider-neutral DbContext registration for a base context type. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Repositories.EntityFrameworkCore.IQueryableExtensions](kamisama-repositories-entityframeworkcore/kamisama-repositories-entityframeworkcore-iqueryableextensions/index.md) - Provides the `IQueryableExtensions` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Repositories.EntityFrameworkCore.MultiProviderDbContextBuilder<TBaseContext>](kamisama-repositories-entityframeworkcore/kamisama-repositories-entityframeworkcore-multiproviderdbcontextbuilder-tbasecontext/index.md) - Provides the `MultiProviderDbContextBuilder<TBaseContext>` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Repositories.EntityFrameworkCore.ServiceCollectionExtensions](kamisama-repositories-entityframeworkcore/kamisama-repositories-entityframeworkcore-servicecollectionextensions/index.md) - Provides EF Core service registration extensions. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>](kamisama-repositories-entityframeworkcore-initialization/kamisama-repositories-entityframeworkcore-initialization-databaseinitializerbase-tdbcontext/index.md) - Base EF Core database initializer with migration and seed hooks. Derive from it to centralize production seed data and optional test seed data for one DbContext.
- [KamiSama.Repositories.EntityFrameworkCore.Initialization.DefaultDatabaseInitializer<TDbContext>](kamisama-repositories-entityframeworkcore-initialization/kamisama-repositories-entityframeworkcore-initialization-defaultdatabaseinitializer-tdbcontext/index.md) - Default Initializer, applies migration based on options. Use it with the surrounding package APIs when composing application code.
