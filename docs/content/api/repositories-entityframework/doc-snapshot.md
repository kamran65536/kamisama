---
last-checked-utc: 2026-08-14T23:41:17Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Repositories.EntityFramework.IOrderedQueryableExtensions
---

# Documentation Snapshot

The package description, public and protected API documentation, repository lifecycle caveats, paging behavior, and example coverage were reviewed against the source at the recorded root version.

## Description

Entity Framework 6 repositories with immediate persistence and ordered-query paging.
Use this package to expose tracked EF6 queries through KamiSama repository contracts and produce paged UI or API results.

## How to use

```shell
dotnet add package KamiSama.Repositories.EntityFramework --version 10.0.0
```

Construct either `DbRepository<TEntity>` or `DbRepository<TEntity, TDbContext>` with an application-owned EF6 context. Queries are deferred and tracking by default. Every add, update, and delete immediately calls `SaveChanges` or `SaveChangesAsync`; repository disposal intentionally does not dispose the context. Apply deterministic ordering before `MakePagedAsync<T>`. Paging counts synchronously without cancellation and materializes in a separate cancellable asynchronous query, so concurrent changes can make count and items inconsistent.

## Example decisions

Both `KamiSama.Repositories.EntityFramework.DbRepository<TEntity>` and `KamiSama.Repositories.EntityFramework.DbRepository<TEntity, TDbContext>` have distinct full-name-matched class examples. Static `IOrderedQueryableExtensions` is exempt from a separate class-level example because this How-to and its sole full-name-and-member-scoped `MakePagedAsync<T>` example demonstrate the complete workflow.
