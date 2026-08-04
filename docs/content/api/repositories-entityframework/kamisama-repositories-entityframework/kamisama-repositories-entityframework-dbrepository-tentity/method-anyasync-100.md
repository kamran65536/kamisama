# AnyAsync

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:100](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L100)

Type: `KamiSama.Repositories.EntityFramework.DbRepository<TEntity>`

Kind: `Method`

## Description

Checks if any entity exists in the repository. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The `predicate` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | Returns a `Task<bool>` value. |

## Example

No concise standalone example is available yet.

