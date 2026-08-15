# UpdateAsync

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/DbRepository.cs:62](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/DbRepository.cs#L62)

Type: `KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>`

Kind: `Method`

## Description

Marks an entity as modified and immediately saves the context asynchronously. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual Task UpdateAsync(TEntity item, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The entity whose complete mapped state should be treated as modified. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the save operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that completes after EF Core saves the context. |

## Example

```csharp
await repository.UpdateAsync(user, cancellationToken);
```

