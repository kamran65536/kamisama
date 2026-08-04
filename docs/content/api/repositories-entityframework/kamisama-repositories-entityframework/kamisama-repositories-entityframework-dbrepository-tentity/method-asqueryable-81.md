# AsQueryable

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:81](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L81)

Type: `KamiSama.Repositories.EntityFramework.DbRepository<TEntity>`

Kind: `Method`

## Description

Returns the db set as queryable. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual IQueryable<TEntity> AsQueryable();
```

## Parameters

This member does not declare parameters.

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

