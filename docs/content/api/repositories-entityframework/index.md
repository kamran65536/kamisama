# KamiSama.Repositories.EntityFramework

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Entity Framework 6 repositories with immediate persistence and ordered-query paging. Use this package to expose tracked EF6 queries through KamiSama repository contracts and produce paged UI or API results.

## How to use

```shell
dotnet add package KamiSama.Repositories.EntityFramework --version 10.0.0
```

Construct a repository with an application-owned EF6 context. Mutations save immediately, while queries remain tracked and deferred:

```csharp
using KamiSama.Extensions.Paging;
using KamiSama.Repositories.EntityFramework;

var repository = new DbRepository<User, AppDbContext>(dbContext);
await repository.AddAsync(new User { Name = "Ada" }, cancellationToken);
PagedResult<User> page = await repository.AsQueryable()
    .OrderBy(user => user.Id)
    .MakePagedAsync(SearchModel.FromPage(1, 20), cancellationToken);
```

The repository does not own or dispose the context. Each add, update, or delete calls `SaveChanges` immediately rather than participating in a repository-level unit of work. Queries track entities by default. Paging requires an ordered query, performs a synchronous uncancellable count before cancellable asynchronous materialization, and uses separate count and data queries.

## Namespaces

- [KamiSama.Repositories.EntityFramework](kamisama-repositories-entityframework/index.md) (3 types)

## Types

- [KamiSama.Repositories.EntityFramework.DbRepository<TEntity, TDbContext>](kamisama-repositories-entityframework/kamisama-repositories-entityframework-dbrepository-tentity-tdbcontext/index.md) - EF6 repository over a borrowed `DbContext`. Queries track by default, every mutation saves immediately, and repository disposal does not dispose the context.
- [KamiSama.Repositories.EntityFramework.DbRepository<TEntity>](kamisama-repositories-entityframework/kamisama-repositories-entityframework-dbrepository-tentity/index.md) - EF6 repository over a borrowed `DbContext`. Queries track by default, every mutation saves immediately, and repository disposal does not dispose the context.
- [KamiSama.Repositories.EntityFramework.IOrderedQueryableExtensions](kamisama-repositories-entityframework/kamisama-repositories-entityframework-iorderedqueryableextensions/index.md) - Pages ordered EF6 queries by synchronously counting all matches and asynchronously materializing one page. Cancellation does not cover the count, and count and data are separate queries.
