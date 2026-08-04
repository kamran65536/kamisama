# SaveFailed

[Back to XmlFileRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlFileRepository.cs:40](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlFileRepository.cs#L40)

Type: `KamiSama.Repositories.Xml.XmlFileRepository<TEntity>`

Kind: `Event`

## Description

raised when saving items to file fails. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public event Action<XmlFileRepository<TEntity>, Exception>? SaveFailed;
```

## Value

| Detail | Description |
| --- | --- |
| `Event` | Event handlers use `Action<XmlFileRepository<TEntity>, Exception>?`. |

## Example

No concise standalone example is available yet.

