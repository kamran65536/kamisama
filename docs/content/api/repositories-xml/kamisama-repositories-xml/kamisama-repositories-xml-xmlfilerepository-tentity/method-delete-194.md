# Delete

[Back to XmlFileRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlFileRepository.cs:194](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlFileRepository.cs#L194)

Type: `KamiSama.Repositories.Xml.XmlFileRepository<TEntity>`

Kind: `Method`

## Description

Runs the `Delete` operation on `XmlFileRepository<TEntity>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public void Delete(TEntity item);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The `item` value passed to this member. |

## Example

```csharp
var entity = new SampleEntity { Id = 1, Name = "Test" };
var context = GetDbContext(initialDbSet: [entity]);

var repository = new DbRepository<SampleEntity>(context);

repository.Delete(entity);
```

