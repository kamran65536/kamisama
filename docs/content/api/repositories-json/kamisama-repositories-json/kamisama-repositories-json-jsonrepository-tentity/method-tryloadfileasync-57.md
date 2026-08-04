# TryLoadFileAsync

[Back to JsonRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:57](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L57)

Type: `KamiSama.Repositories.Json.JsonRepository<TEntity>`

Kind: `Method`

## Description

loads the json file if not loaded already. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public async Task<bool> TryLoadFileAsync(bool forceReload, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `forceReload` | `bool` | `-` | The `forceReload` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | Returns a `Task<bool>` value. |

## Example

```csharp
var repository = new JsonRepository<SampleEntity>("./Json/sample-entities.json");
await repository.TryLoadFileAsync(forceReload: true, CancellationToken.None);

((System.IDisposable)repository).Dispose();
```

