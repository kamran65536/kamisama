# Find

[Back to XmlFileRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlFileRepository.cs:232](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlFileRepository.cs#L232)

Type: `KamiSama.Repositories.Xml.XmlFileRepository<TEntity>`

Kind: `Method`

## Description

Loads on demand and returns the first matching cached entity, or the default value after a load failure, a null predicate, or no match.

## Declaration

```csharp
public TEntity? Find(Expression<Func<TEntity, bool>>? predicate = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>?` | `null` | The predicate to apply, or to return the default value. |

## Returns

| Type | Description |
| --- | --- |
| `TEntity?` | The first matching entity, or the default value when loading fails or no predicate matches. |

## Example

No concise standalone example is available yet.

