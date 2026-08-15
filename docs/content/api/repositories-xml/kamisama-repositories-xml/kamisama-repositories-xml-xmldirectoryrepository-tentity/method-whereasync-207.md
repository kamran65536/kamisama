# WhereAsync

[Back to XmlDirectoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlDirectoryRepository.cs:207](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlDirectoryRepository.cs#L207)

Type: `KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>`

Kind: `Method`

## Description

Loads on demand and returns a live query over the cached set, or an empty query after load failure. Enumeration is not synchronized with mutations.

## Declaration

```csharp
public async Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>?` | `-` | The predicate to compile and apply, or to return all cached entities. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel loading. |

## Returns

| Type | Description |
| --- | --- |
| `Task<IQueryable<TEntity>>` | A live query, or an empty query when loading fails. |

## Remarks

The returned query is not a snapshot and is not protected from later mutations.

## Example

```csharp
IQueryable<User> activeUsers = await directoryRepository.WhereAsync(x => x.IsActive, cancellationToken);
```

