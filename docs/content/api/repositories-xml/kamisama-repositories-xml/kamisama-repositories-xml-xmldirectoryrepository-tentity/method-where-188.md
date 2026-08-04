# Where

[Back to XmlDirectoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlDirectoryRepository.cs:188](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlDirectoryRepository.cs#L188)

Type: `KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>`

Kind: `Method`

## Description

Runs the `Where` operation on `XmlDirectoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>>? predicate = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>?` | `null` | The `predicate` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `IQueryable<TEntity>` | Returns a `IQueryable<TEntity>` value. |

## Example

```csharp
var sampleCollection = new [] { new SampleEntity()};
Expression<Func<SampleEntity, bool>> predicate = se => true;

var repository = Substitute.For<IQueryableRepository<SampleEntity>>();
repository.Where(Arg.Any<Expression<Func<SampleEntity, bool>>>()).Returns(sampleCollection.AsQueryable());

var result = repository.FirstOrDefault(predicate);

repository.Received().Where(predicate);
```

