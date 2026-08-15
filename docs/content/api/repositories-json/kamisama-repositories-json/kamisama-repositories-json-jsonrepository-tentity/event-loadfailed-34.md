# LoadFailed

[Back to JsonRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:34](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L34)

Type: `KamiSama.Repositories.Json.JsonRepository<TEntity>`

Kind: `Event`

## Description

Raised after reading or deserializing the JSON file fails. The load otherwise returns `false` and query methods return default or empty results.

## Declaration

```csharp
public event Action<JsonRepository<TEntity>, Exception>? LoadFailed;
```

## Value

| Detail | Description |
| --- | --- |
| `Event` | Event handlers use `Action<JsonRepository<TEntity>, Exception>?`. |

## Remarks

After this event is raised, the load method returns unless an event handler throws.

## Example

No concise standalone example is available yet.

