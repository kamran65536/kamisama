# Where

[Back to InMemoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/InMemoryRepository.cs:86](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/InMemoryRepository.cs#L86)

Type: `KamiSama.Repositories.InMemoryRepository<TEntity>`

Kind: `Method`

## Description

Returns a live, unsynchronized query over the in-memory set. Do not enumerate it concurrently with add, delete, or disposal.

## Declaration

```csharp
public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The predicate to compile and apply, or to return all entities. |

## Returns

| Type | Description |
| --- | --- |
| `IQueryable<TEntity>` | A live query over the internal set. |

## Remarks

The returned query is not a snapshot and is not synchronized with mutations.

## Example

No concise standalone example is available yet.

