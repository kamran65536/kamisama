# FindAsync

[Back to XmlDirectoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlDirectoryRepository.cs:168](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlDirectoryRepository.cs#L168)

Type: `KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>`

Kind: `Method`

## Description

Runs the `FindAsync` operation on `XmlDirectoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>?` | `-` | The `predicate` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntity?>` | Returns a `Task<TEntity?>` value. |

## Example

```csharp
var entity = new SampleEntity { Id = 1, Name = "Test" };
var context = GetDbContext(initialDbSet: [entity]);
var repository = new DbRepository<SampleEntity>(context);

var result = await repository.FindAsync(x => x.Id == 1, CancellationToken.None);

var result2 = await repository.FindAsync(x => x.Id == 2, CancellationToken.None);
```

