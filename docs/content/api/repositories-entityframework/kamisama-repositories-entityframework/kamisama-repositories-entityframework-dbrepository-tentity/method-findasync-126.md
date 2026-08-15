# FindAsync

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:126](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L126)

Type: `KamiSama.Repositories.EntityFramework.DbRepository<TEntity>`

Kind: `Method`

## Description

Asynchronously returns the first tracked entity matching a predicate. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The expression translated by the EF6 query provider. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel query execution. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntity?>` | A task containing the first matching entity, or when no entity matches. |

## Example

```csharp
User? user = await repository.FindAsync(user => user.Id == userId, cancellationToken);
```

