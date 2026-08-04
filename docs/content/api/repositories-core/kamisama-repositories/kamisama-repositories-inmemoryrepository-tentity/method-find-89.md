# Find

[Back to InMemoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/InMemoryRepository.cs:89](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/InMemoryRepository.cs#L89)

Type: `KamiSama.Repositories.InMemoryRepository<TEntity>`

Kind: `Method`

## Description

Finds an single item in the repository. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual TEntity? Find(Expression<Func<TEntity, bool>>? predicate);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>?` | `-` | the predicate to search, if null it returns null |

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

