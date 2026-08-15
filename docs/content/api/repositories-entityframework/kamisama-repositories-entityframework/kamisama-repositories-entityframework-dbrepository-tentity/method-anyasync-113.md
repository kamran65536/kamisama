# AnyAsync

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:113](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L113)

Type: `KamiSama.Repositories.EntityFramework.DbRepository<TEntity>`

Kind: `Method`

## Description

Determines asynchronously whether any entity matches a predicate. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The expression translated by the EF6 query provider. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel query execution. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | A task containing when at least one entity matches; otherwise, . |

## Example

```csharp
bool exists = await repository.AnyAsync(user => user.Email == email, cancellationToken);
```

