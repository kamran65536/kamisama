# SaveFailed

[Back to XmlDirectoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlDirectoryRepository.cs:40](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlDirectoryRepository.cs#L40)

Type: `KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>`

Kind: `Event`

## Description

raised when saving items to file fails. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public event Action<XmlDirectoryRepository<TEntity>, Exception>? SaveFailed;
```

## Value

| Detail | Description |
| --- | --- |
| `Event` | Event handlers use `Action<XmlDirectoryRepository<TEntity>, Exception>?`. |

## Example

No concise standalone example is available yet.

