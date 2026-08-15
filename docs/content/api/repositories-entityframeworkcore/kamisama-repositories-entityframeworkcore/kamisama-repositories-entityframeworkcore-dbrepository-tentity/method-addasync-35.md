# AddAsync

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/DbRepository.cs:35](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/DbRepository.cs#L35)

Type: `KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>`

Kind: `Method`

## Description

Adds an entity to the set and immediately saves the context asynchronously. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual Task AddAsync(TEntity item, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The entity to add and track. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the save operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that completes after EF Core saves the context. |

## Example

```csharp
await repository.AddAsync(user, cancellationToken); // Saves immediately.
```

