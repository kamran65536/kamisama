# UpdateAsync

[Back to XmlFileRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlFileRepository.cs:186](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlFileRepository.cs#L186)

Type: `KamiSama.Repositories.Xml.XmlFileRepository<TEntity>`

Kind: `Method`

## Description

Ignores the supplied entity and cannot durably update XML in version 10.0.0; saving also ignores the supplied serializer.

## Declaration

```csharp
public Task UpdateAsync(TEntity? item, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity?` | `-` | The entity value, which is ignored. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel loading, the semaphore wait, or the attempted write. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that completes after the failed or ineffective persistence attempt. |

## Remarks

In version 10.0.0 this does not durably update an XML entity file and does not use the supplied serializer for output.

## Example

No concise standalone example is available yet.

