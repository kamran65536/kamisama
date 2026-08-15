# Where

[Back to IQueryableRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/IQueryableRepository.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IQueryableRepository.cs#L16)

Type: `KamiSama.Repositories.IQueryableRepository<TEntity>`

Kind: `Method`

## Description

Returns an `IQueryable<TEntity>` filtered by the predicate. The implementation determines whether the query is translated, deferred, live, or a snapshot; this method is synchronous on both interfaces.

## Declaration

```csharp
IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The predicate used to filter entities. Implementations may accept to return all entities. |

## Returns

| Type | Description |
| --- | --- |
| `IQueryable<TEntity>` | A query containing matching entities. |

## Example

```csharp
IQueryable<User> activeUsers = repository.Where(user => user.IsActive);
```

