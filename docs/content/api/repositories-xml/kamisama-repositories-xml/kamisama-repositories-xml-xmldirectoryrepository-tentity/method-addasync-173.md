# AddAsync

[Back to XmlDirectoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlDirectoryRepository.cs:173](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlDirectoryRepository.cs#L173)

Type: `KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>`

Kind: `Method`

## Description

Changes the in-memory set but cannot durably create a mapped XML entity file in version 10.0.0; the save path writes to the directory path.

## Declaration

```csharp
public Task AddAsync(TEntity item, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The entity to add in memory. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel loading, the semaphore wait, or the attempted write. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that completes after the failed or ineffective persistence attempt. |

## Remarks

In version 10.0.0 this cannot durably add an XML entity file. A write failure raises `SaveFailed` after the cache has changed.

## Example

No concise standalone example is available yet.

