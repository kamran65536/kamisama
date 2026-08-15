---
last-checked-utc: 2026-08-14T23:24:08Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Repositories.RepositoriesExtensions
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, persistence and concurrency caveats, and example coverage were reviewed against the source at the recorded root version.

## Description

Repository contracts, an in-memory implementation, connection-string options, and database initialization abstractions.
Use this package to keep callers independent of persistence or to hold transient entities in tests and lightweight processes.

## How to use

```shell
dotnet add package KamiSama.Repositories.Core --version 10.0.0
```

Use the interfaces as contracts rather than assuming durability, transactions, duplicate handling, cancellation guarantees, or snapshot queries. `IAsyncQueryableRepository<TEntity>.Where` remains synchronous. `InMemoryRepository<TEntity>` uses `HashSet<TEntity>` equality, has no-op update methods, serializes add and delete per instance, and does not synchronize reads or live-query enumeration with mutations. Initializer and provider implementations decide how the option objects are applied.

## Example decisions

`ConnectionStringOption`, `DataInitializationOptions`, and `InMemoryRepository<TEntity>` have full-name-matched class examples. Static `RepositoriesExtensions` is exempt because the package How-to demonstrates both `FirstOrDefault` and `GetAll`. Interfaces are not class exemptions; every repository and initialization interface has a useful full-name-scoped type example, and its members have full-name-and-member-scoped examples.
