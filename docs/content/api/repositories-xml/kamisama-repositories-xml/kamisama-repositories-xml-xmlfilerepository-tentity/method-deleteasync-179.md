# DeleteAsync

[Back to XmlFileRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlFileRepository.cs:179](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlFileRepository.cs#L179)

Type: `KamiSama.Repositories.Xml.XmlFileRepository<TEntity>`

Kind: `Method`

## Description

Changes the in-memory set but does not delete the mapped XML file in version 10.0.0, including when the final cached entity is removed.

## Declaration

```csharp
public Task DeleteAsync(TEntity item, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The entity used for equality-based removal. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel loading, the semaphore wait, or the attempted write. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that completes after the failed or ineffective persistence attempt. |

## Remarks

In version 10.0.0 this does not delete the entity&apos;s XML file, including when deleting the final cached entity.

## Example

No concise standalone example is available yet.

