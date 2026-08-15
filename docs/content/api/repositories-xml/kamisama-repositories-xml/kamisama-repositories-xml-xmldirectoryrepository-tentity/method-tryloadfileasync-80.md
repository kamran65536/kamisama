# TryLoadFileAsync

[Back to XmlDirectoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlDirectoryRepository.cs:80](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlDirectoryRepository.cs#L80)

Type: `KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>`

Kind: `Method`

## Description

Loads all `*.xml` files as individual entities and validates mapped names. The version 10.0.0 default array serializer cannot perform these per-entity reads, and equal entities are silently collapsed.

## Declaration

```csharp
public async Task<bool> TryLoadFileAsync(bool forceReload, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `forceReload` | `bool` | `-` | Whether to discard the cached set and enumerate the directory again. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel file reads or the semaphore wait. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | when every file loads and validates; otherwise after raising `LoadFailed`. |

## Remarks

Each file is deserialized as one entity and must have exactly the name returned by the mapping function. Equal entities from separate files are silently collapsed by the set. The version 10.0.0 default serializer targets &lt;typeparamref name=&quot;TEntity&quot;/&gt; arrays and therefore fails for these per-entity reads.

## Example

```csharp
bool loaded = await directoryRepository.TryLoadFileAsync(forceReload: true, cancellationToken);
```

