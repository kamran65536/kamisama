# KamiSama.Repositories.Core

[Back to package index](../index.md)

Version: `10.0.10`

## Description

Core repository interfaces, in-memory repository implementation, connection-string options, and database initialization contracts. Use it with the surrounding package APIs when composing application code.

## Install

```shell
dotnet add package KamiSama.Repositories.Core --version 10.0.10
```

## Namespaces

- [KamiSama.Repositories](kamisama-repositories/index.md) (7 types)
- [KamiSama.Repositories.Initialization](kamisama-repositories-initialization/index.md) (2 types)

## Types

- [KamiSama.Repositories.ConnectionStringOption](kamisama-repositories/kamisama-repositories-connectionstringoption/index.md) - Configuration object for database provider and connection-string settings. Bind it from configuration when wiring repository or DbContext provider packages.
- [KamiSama.Repositories.IAsyncQueryableRepository<TEntity>](kamisama-repositories/kamisama-repositories-iasyncqueryablerepository-tentity/index.md) - IAsyncQueryable Repository. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Repositories.IAsyncRepository<_EntityType>](kamisama-repositories/kamisama-repositories-iasyncrepository-entitytype/index.md) - IAsyncRepository is the same as IRepository. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Repositories.InMemoryRepository<TEntity>](kamisama-repositories/kamisama-repositories-inmemoryrepository-tentity/index.md) - The internal memory repository, this class can be used for testing The class operations are thread safe. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Repositories.IQueryableRepository<TEntity>](kamisama-repositories/kamisama-repositories-iqueryablerepository-tentity/index.md) - Queryable Repository Interface, these repositories can be searched throughout. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Repositories.IRepository<TEntity>](kamisama-repositories/kamisama-repositories-irepository-tentity/index.md) - Repository implementation or contract for `IRepository<TEntity>`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.
- [KamiSama.Repositories.RepositoriesExtensions](kamisama-repositories/kamisama-repositories-repositoriesextensions/index.md) - Provides the `RepositoriesExtensions` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Repositories.Initialization.DataInitializationOptions](kamisama-repositories-initialization/kamisama-repositories-initialization-datainitializationoptions/index.md) - Options object that controls database initialization work. Use it to turn migration, normal seed data, and test seed data on or off.
- [KamiSama.Repositories.Initialization.IDatabaseInitializer<TDbContext>](kamisama-repositories-initialization/kamisama-repositories-initialization-idatabaseinitializer-tdbcontext/index.md) - Generic Data Initialization interface. Use it with the surrounding package APIs when composing application code.
