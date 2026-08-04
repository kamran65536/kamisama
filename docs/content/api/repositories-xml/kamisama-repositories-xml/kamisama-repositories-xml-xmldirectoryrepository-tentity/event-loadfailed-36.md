# LoadFailed

[Back to XmlDirectoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlDirectoryRepository.cs:36](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlDirectoryRepository.cs#L36)

Type: `KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>`

Kind: `Event`

## Description

raised when loading items from file fails. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public event Action<XmlDirectoryRepository<TEntity>, Exception>? LoadFailed;
```

## Value

| Detail | Description |
| --- | --- |
| `Event` | Event handlers use `Action<XmlDirectoryRepository<TEntity>, Exception>?`. |

## Example

No concise standalone example is available yet.

