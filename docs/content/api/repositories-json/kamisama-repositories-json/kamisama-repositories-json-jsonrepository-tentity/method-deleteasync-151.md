# DeleteAsync

[Back to JsonRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:151](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L151)

Type: `KamiSama.Repositories.Json.JsonRepository<TEntity>`

Kind: `Method`

## Description

Removes according to `HashSet<TEntity>` equality and rewrites the complete JSON file. Failed writes do not restore the removed entity.

## Declaration

```csharp
public Task DeleteAsync(TEntity item, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The entity used for equality-based removal. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel loading, the semaphore wait, or file writing. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that completes after the write attempt; inspect `LoadFailed` and `SaveFailed` for suppressed failures. |

## Remarks

A missing entity is ignored but the file is still rewritten. A save failure does not restore a removed entity.

## Example

No concise standalone example is available yet.

