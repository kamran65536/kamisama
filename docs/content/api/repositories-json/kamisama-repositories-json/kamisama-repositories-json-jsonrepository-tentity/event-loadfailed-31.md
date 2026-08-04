# LoadFailed

[Back to JsonRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:31](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L31)

Type: `KamiSama.Repositories.Json.JsonRepository<TEntity>`

Kind: `Event`

## Description

raised when loading items from file fails. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public event Action<JsonRepository<TEntity>, Exception>? LoadFailed;
```

## Value

| Detail | Description |
| --- | --- |
| `Event` | Event handlers use `Action<JsonRepository<TEntity>, Exception>?`. |

## Example

No concise standalone example is available yet.

