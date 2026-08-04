# Update

[Back to IRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/IRepository.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IRepository.cs#L21)

Type: `KamiSama.Repositories.IRepository<TEntity>`

Kind: `Method`

## Description

Update method, does nothing. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
void Update(TEntity item);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The `item` value passed to this member. |

## Example

```csharp
var sample = new SampleEntity { Id = 1, Name = "sample" };
var repository = new InMemoryRepository<SampleEntity>([sample]);

sample.Name = "sample2";

repository.Update(sample);

var retrieved = repository.Find(x => x.Name == "sample2");
```

