# DeleteAsync

[Back to InMemoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/InMemoryRepository.cs:120](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/InMemoryRepository.cs#L120)

Type: `KamiSama.Repositories.InMemoryRepository<TEntity>`

Kind: `Method`

## Description

Removes an equal entity from the in-memory set when present. Mutation is serialized per instance, but concurrent reads are not locked.

## Declaration

```csharp
public virtual async Task DeleteAsync(TEntity item, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The entity used for equality-based removal. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the semaphore wait. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents the in-memory delete operation. |

## Example

No concise standalone example is available yet.

