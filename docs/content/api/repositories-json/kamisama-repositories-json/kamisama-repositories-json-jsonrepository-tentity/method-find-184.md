# Find

[Back to JsonRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:184](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L184)

Type: `KamiSama.Repositories.Json.JsonRepository<TEntity>`

Kind: `Method`

## Description

Finds an single item in the repository. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public TEntity? Find(Expression<Func<TEntity, bool>>? predicate = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>?` | `null` | the predicate to search, if null it returns null |

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

