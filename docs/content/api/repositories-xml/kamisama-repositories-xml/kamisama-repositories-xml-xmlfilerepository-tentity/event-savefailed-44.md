# SaveFailed

[Back to XmlFileRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlFileRepository.cs:44](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlFileRepository.cs#L44)

Type: `KamiSama.Repositories.Xml.XmlFileRepository<TEntity>`

Kind: `Event`

## Description

Raised after the broken mutation path attempts to write serialized entities to the directory path. In-memory changes are not rolled back.

## Declaration

```csharp
public event Action<XmlFileRepository<TEntity>, Exception>? SaveFailed;
```

## Value

| Detail | Description |
| --- | --- |
| `Event` | Event handlers use `Action<XmlFileRepository<TEntity>, Exception>?`. |

## Remarks

The in-memory mutation is not rolled back, and the repository method otherwise completes normally unless an event handler throws.

## Example

No concise standalone example is available yet.

