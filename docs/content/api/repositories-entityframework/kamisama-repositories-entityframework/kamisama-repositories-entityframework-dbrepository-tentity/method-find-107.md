# Find

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:107](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L107)

Type: `KamiSama.Repositories.EntityFramework.DbRepository<TEntity>`

Kind: `Method`

## Description

Finds an item in the repository. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual TEntity? Find(Expression<Func<TEntity, bool>> predicate);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The `predicate` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `TEntity?` | Returns a `TEntity?` value. |

## Example

```csharp
var sample = new SampleEntity { Id = 1, Name = "sample" };
var repository = new InMemoryRepository<SampleEntity>([sample]);

sample.Name = "sample2";

repository.Update(sample);

var retrieved = repository.Find(x => x.Name == "sample2");
```

