# UpdateAsync

[Back to InMemoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/InMemoryRepository.cs:113](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/InMemoryRepository.cs#L113)

Type: `KamiSama.Repositories.InMemoryRepository<TEntity>`

Kind: `Method`

## Description

Performs no operation; this repository does not replace or merge entities.

## Declaration

```csharp
public Task UpdateAsync(TEntity item, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The entity value, which is ignored. |
| `cancellationToken` | `CancellationToken` | `-` | A token that is not observed because no work is performed. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | An already-completed task. |

## Example

No concise standalone example is available yet.

