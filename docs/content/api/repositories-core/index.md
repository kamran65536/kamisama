# KamiSama.Repositories.Core

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Repository contracts, an in-memory implementation, connection-string options, and database initialization abstractions. Use it to keep callers independent of persistence or to hold transient entities in tests and lightweight processes.

## How to use

```shell
dotnet add package KamiSama.Repositories.Core --version 10.0.0
```

Use the contracts to keep callers independent of persistence, or use `InMemoryRepository<TEntity>` for transient data and tests. Its update methods are no-ops, duplicate handling follows `HashSet<TEntity>` equality, and live queries must not be enumerated concurrently with mutations:

```csharp
using KamiSama.Repositories;

using var repository = new InMemoryRepository<User>(users, UserIdComparer.Instance);
User? admin = repository.FirstOrDefault(user => user.IsAdmin);
List<User> allUsers = repository.GetAll().ToList();
```

The repository interfaces do not define durability, transactions, duplicate behavior, cancellation guarantees, or whether returned queries are snapshots. `IAsyncQueryableRepository<TEntity>.Where` is synchronous despite the interface name. `ConnectionStringOption` and `DataInitializationOptions` are configuration data only; an initializer or provider implementation decides how their values are applied.

## Namespaces

- [KamiSama.Repositories](kamisama-repositories/index.md) (7 types)
- [KamiSama.Repositories.Initialization](kamisama-repositories-initialization/index.md) (2 types)

## Types

- [KamiSama.Repositories.ConnectionStringOption](kamisama-repositories/kamisama-repositories-connectionstringoption/index.md) - Contains the provider identifier and connection string bound from configuration. Provider packages decide which identifiers they accept and how the connection string is used.
- [KamiSama.Repositories.IAsyncQueryableRepository<TEntity>](kamisama-repositories/kamisama-repositories-iasyncqueryablerepository-tentity/index.md) - Combines asynchronous repository operations with a synchronous `Where` method returning `IQueryable<TEntity>`. The interface name does not make query creation or enumeration asynchronous.
- [KamiSama.Repositories.IAsyncRepository<_EntityType>](kamisama-repositories/kamisama-repositories-iasyncrepository-entitytype/index.md) - Adds asynchronous mutation and lookup methods to `IRepository<TEntity>`. Implementations determine whether work is truly asynchronous and how cancellation, failures, and persistence are handled.
- [KamiSama.Repositories.InMemoryRepository<TEntity>](kamisama-repositories/kamisama-repositories-inmemoryrepository-tentity/index.md) - Stores entities in an in-process `HashSet<TEntity>` for tests and transient scenarios. Add and delete are serialized per instance, update is a no-op, duplicate semantics follow the comparer, and reads or live queries are not synchronized with mutations.
- [KamiSama.Repositories.IQueryableRepository<TEntity>](kamisama-repositories/kamisama-repositories-iqueryablerepository-tentity/index.md) - Adds predicate-based query access to the synchronous repository contract. The implementation decides whether the returned `IQueryable<TEntity>` is translated, deferred, live, or an in-memory snapshot.
- [KamiSama.Repositories.IRepository<TEntity>](kamisama-repositories/kamisama-repositories-irepository-tentity/index.md) - Defines synchronous add, update, delete, and first-match lookup operations. Implementations determine persistence, transaction, duplicate, and missing-entity behavior.
- [KamiSama.Repositories.RepositoriesExtensions](kamisama-repositories/kamisama-repositories-repositoriesextensions/index.md) - Provides first-match and all-entity convenience queries for `IQueryableRepository<TEntity>`. Both methods delegate to the repository's `Where` implementation and preserve its query and concurrency semantics.
- [KamiSama.Repositories.Initialization.DataInitializationOptions](kamisama-repositories-initialization/kamisama-repositories-initialization-datainitializationoptions/index.md) - Selects whether a database initializer should migrate, create required application data, or create test data. The `IDatabaseInitializer<TDbContext>` implementation defines the actual work and ordering.
- [KamiSama.Repositories.Initialization.IDatabaseInitializer<TDbContext>](kamisama-repositories-initialization/kamisama-repositories-initialization-idatabaseinitializer-tdbcontext/index.md) - Defines migration and seed-data initialization for one database context type. Implementations interpret `DataInitializationOptions` and own ordering, idempotency, persistence, and failure behavior.
