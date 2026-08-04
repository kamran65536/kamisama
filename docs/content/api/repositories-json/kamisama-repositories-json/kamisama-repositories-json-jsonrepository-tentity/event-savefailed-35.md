# SaveFailed

[Back to JsonRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:35](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L35)

Type: `KamiSama.Repositories.Json.JsonRepository<TEntity>`

Kind: `Event`

## Description

raised when saving items to file fails. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public event Action<JsonRepository<TEntity>, Exception>? SaveFailed;
```

## Value

| Detail | Description |
| --- | --- |
| `Event` | Event handlers use `Action<JsonRepository<TEntity>, Exception>?`. |

## Example

No concise standalone example is available yet.

