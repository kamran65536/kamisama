# FindAsync

[Back to XmlDirectoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlDirectoryRepository.cs:193](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlDirectoryRepository.cs#L193)

Type: `KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>`

Kind: `Method`

## Description

Loads on demand and returns the first matching cached entity, or the default value after a load failure, a null predicate, or no match.

## Declaration

```csharp
public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>?` | `-` | The predicate to compile and apply, or to return the default value. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel loading. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntity?>` | The first matching entity, or the default value when loading fails, the predicate is , or no entity matches. |

## Example

```csharp
User? user = await directoryRepository.FindAsync(x => x.Id == userId, cancellationToken);
```

