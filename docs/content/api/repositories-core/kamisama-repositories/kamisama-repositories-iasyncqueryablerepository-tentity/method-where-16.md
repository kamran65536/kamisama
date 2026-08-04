# Where

[Back to IAsyncQueryableRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/IAsyncQueryableRepository.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IAsyncQueryableRepository.cs#L16)

Type: `KamiSama.Repositories.IAsyncQueryableRepository<TEntity>`

Kind: `Method`

## Description

the same as Where, just to indicate async behavior. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The `predicate` value passed to this member. |

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

