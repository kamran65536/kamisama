# Where

[Back to InMemoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/InMemoryRepository.cs:82](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/InMemoryRepository.cs#L82)

Type: `KamiSama.Repositories.InMemoryRepository<TEntity>`

Kind: `Method`

## Description

Queries items in repository for the predicate specified. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | the predicate to search, if null it returns all items |

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

