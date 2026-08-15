# AddAsync

[Back to JsonRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:144](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L144)

Type: `KamiSama.Repositories.Json.JsonRepository<TEntity>`

Kind: `Method`

## Description

Adds according to `HashSet<TEntity>` equality and rewrites the complete JSON file. Equal duplicates are ignored, and failed writes do not roll back memory.

## Declaration

```csharp
public Task AddAsync(TEntity item, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The entity to add. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel loading, the semaphore wait, or file writing. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that completes after the write attempt; inspect `LoadFailed` and `SaveFailed` for suppressed failures. |

## Remarks

An equal duplicate is ignored by the set but the file is still rewritten. A save failure leaves the changed cache in memory.

## Example

No concise standalone example is available yet.

