# Where

[Back to XmlDirectoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlDirectoryRepository.cs:219](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlDirectoryRepository.cs#L219)

Type: `KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>`

Kind: `Method`

## Description

Loads on demand and returns a live query over the cached set, or an empty query after load failure. Enumeration is not synchronized with mutations.

## Declaration

```csharp
public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>>? predicate = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>?` | `null` | The predicate to apply, or to return all cached entities. |

## Returns

| Type | Description |
| --- | --- |
| `IQueryable<TEntity>` | A live query, or an empty query when loading fails. |

## Example

No concise standalone example is available yet.

