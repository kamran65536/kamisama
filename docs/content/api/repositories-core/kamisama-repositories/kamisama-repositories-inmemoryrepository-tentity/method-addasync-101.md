# AddAsync

[Back to InMemoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/InMemoryRepository.cs:101](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/InMemoryRepository.cs#L101)

Type: `KamiSama.Repositories.InMemoryRepository<TEntity>`

Kind: `Method`

## Description

Adds the entity to the in-memory set unless an equal entity already exists. Mutation is serialized per instance, but concurrent reads are not locked.

## Declaration

```csharp
public virtual async Task AddAsync(TEntity item, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The entity to add. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the semaphore wait. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents the in-memory add operation. |

## Example

No concise standalone example is available yet.

