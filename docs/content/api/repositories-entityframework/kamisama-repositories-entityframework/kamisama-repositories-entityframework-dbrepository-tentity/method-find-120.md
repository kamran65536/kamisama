# Find

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:120](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L120)

Type: `KamiSama.Repositories.EntityFramework.DbRepository<TEntity>`

Kind: `Method`

## Description

Returns the first tracked entity matching a predicate. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual TEntity? Find(Expression<Func<TEntity, bool>> predicate);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The expression translated by the EF6 query provider. |

## Returns

| Type | Description |
| --- | --- |
| `TEntity?` | The first matching entity, or when no entity matches. |

## Example

```csharp
User? user = repository.Find(user => user.Id == userId);
```

