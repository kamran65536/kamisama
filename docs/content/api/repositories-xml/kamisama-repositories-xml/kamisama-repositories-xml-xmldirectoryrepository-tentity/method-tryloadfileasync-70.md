# TryLoadFileAsync

[Back to XmlDirectoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlDirectoryRepository.cs:70](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlDirectoryRepository.cs#L70)

Type: `KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>`

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

