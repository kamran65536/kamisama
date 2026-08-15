# KamiSama.Repositories.Json

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Lazy-loading JSON file repository with synchronous and asynchronous query and mutation APIs. It caches entities in memory and rewrites an existing JSON array file after each mutation, with important failure, atomicity, and concurrency limitations.

## How to use

```shell
dotnet add package KamiSama.Repositories.Json --version 10.0.0
```

Point `JsonRepository<TEntity>` at an existing file containing a JSON array, subscribe to failure events, and prefer asynchronous reads:

```csharp
using KamiSama.Repositories.Json;

using var repository = new JsonRepository<User>("data/users.json", UserIdComparer.Instance);
repository.LoadFailed += (_, error) => logger.LogError(error, "Could not load users");
repository.SaveFailed += (_, error) => logger.LogError(error, "Could not save users");

User? user = await repository.FindAsync(x => x.Id == userId, cancellationToken);
```

The repository loads lazily and cannot initialize a missing or invalid file. Mutations rewrite the complete JSON array non-atomically; `Update` only rewrites objects already changed in memory. Save failures are suppressed after raising `SaveFailed`, do not roll back the cache, and can leave partial file content. Locking is per instance, queries are live, and separate instances or processes can overwrite each other. Duplicate behavior follows the configured `HashSet<TEntity>` comparer.

## Namespaces

- [KamiSama.Repositories.Json](kamisama-repositories-json/index.md) (1 types)

## Types

- [KamiSama.Repositories.Json.JsonRepository<TEntity>](kamisama-repositories-json/kamisama-repositories-json-jsonrepository-tentity/index.md) - Lazily reads an existing JSON array into a `HashSet<TEntity>` and rewrites the complete file after mutations. Writes are non-atomic, update only persists prior in-memory changes, failures are event-reported and suppressed, and locking does not coordinate live queries or other instances.
