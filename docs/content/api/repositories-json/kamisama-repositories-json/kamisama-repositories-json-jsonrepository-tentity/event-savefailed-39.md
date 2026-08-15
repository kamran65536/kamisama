# SaveFailed

[Back to JsonRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:39](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L39)

Type: `KamiSama.Repositories.Json.JsonRepository<TEntity>`

Kind: `Event`

## Description

Raised after an in-memory mutation or non-atomic full-file write fails. The changed cache is not rolled back and the operation otherwise completes normally.

## Declaration

```csharp
public event Action<JsonRepository<TEntity>, Exception>? SaveFailed;
```

## Value

| Detail | Description |
| --- | --- |
| `Event` | Event handlers use `Action<JsonRepository<TEntity>, Exception>?`. |

## Remarks

The in-memory mutation is not rolled back. The repository method otherwise completes normally unless an event handler throws.

## Example

No concise standalone example is available yet.

