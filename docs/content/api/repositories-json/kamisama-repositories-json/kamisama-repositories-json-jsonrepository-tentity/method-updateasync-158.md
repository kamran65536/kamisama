# UpdateAsync

[Back to JsonRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:158](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L158)

Type: `KamiSama.Repositories.Json.JsonRepository<TEntity>`

Kind: `Method`

## Description

Ignores the supplied entity and rewrites the current set, so it only persists prior changes made to an object already cached by the repository.

## Declaration

```csharp
public Task UpdateAsync(TEntity item, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The entity value, which is ignored. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel loading, the semaphore wait, or file writing. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that completes after the write attempt; inspect `LoadFailed` and `SaveFailed` for suppressed failures. |

## Remarks

This method does not replace or merge an entity. It only persists prior mutations made to an object already held by the set.

## Example

No concise standalone example is available yet.

