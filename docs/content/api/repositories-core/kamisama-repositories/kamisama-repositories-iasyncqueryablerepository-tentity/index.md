# IAsyncQueryableRepository<TEntity>

<a id="iasyncqueryablerepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/IAsyncQueryableRepository.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IAsyncQueryableRepository.cs#L9)

Namespace: `KamiSama.Repositories`

Kind: `Interface`

## Description

Combines asynchronous repository operations with a synchronous `Where` method returning `IQueryable<TEntity>`. The interface name does not make query creation or enumeration asynchronous.

## Declaration

```csharp
public interface IAsyncQueryableRepository<TEntity> : IAsyncRepository<TEntity>
```

## Example

```csharp
using KamiSama.Repositories;

// Where returns IQueryable<TEntity> synchronously even on this async repository contract.
IQueryable<User> activeUsers = repository.Where(user => user.IsActive);
User? user = await repository.FindAsync(user => user.Id == userId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Where](method-where-16.md) | Returns an `IQueryable<TEntity>` filtered by the predicate. The implementation determines whether the query is translated, deferred, live, or a snapshot; this method is synchronous on both interfaces. |

