# WhereAsync

[Back to XmlFileRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlFileRepository.cs:177](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlFileRepository.cs#L177)

Type: `KamiSama.Repositories.Xml.XmlFileRepository<TEntity>`

Kind: `Method`

## Description

Runs the `WhereAsync` operation on `XmlFileRepository<TEntity>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>?` | `-` | The `predicate` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<IQueryable<TEntity>>` | Returns a `Task<IQueryable<TEntity>>` value. |

## Example

No concise standalone example is available yet.

