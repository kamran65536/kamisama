# IQueryableRepository<TEntity>

<a id="iqueryablerepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/IQueryableRepository.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IQueryableRepository.cs#L9)

Namespace: `KamiSama.Repositories`

Kind: `Interface`

## Description

Adds predicate-based query access to the synchronous repository contract. The implementation decides whether the returned `IQueryable<TEntity>` is translated, deferred, live, or an in-memory snapshot.

## Declaration

```csharp
public interface IQueryableRepository<TEntity> : IRepository<TEntity>
```

## Example

```csharp
using KamiSama.Repositories;

IQueryable<User> activeUsers = repository.Where(user => user.IsActive);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Where](method-where-16.md) | Returns an `IQueryable<TEntity>` filtered by the predicate. The implementation determines whether the query is translated, deferred, live, or a snapshot; this method is synchronous on both interfaces. |

