# Find

[Back to IRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/IRepository.cs:32](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IRepository.cs#L32)

Type: `KamiSama.Repositories.IRepository<TEntity>`

Kind: `Method`

## Description

Returns the first entity matching the predicate, or `null` when none matches.

## Declaration

```csharp
TEntity? Find(Expression<Func<TEntity, bool>> predicate);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The predicate used to select an entity. |

## Returns

| Type | Description |
| --- | --- |
| `TEntity?` | The first matching entity, or . |

## Example

```csharp
User? user = repository.Find(x => x.Id == userId);
```

