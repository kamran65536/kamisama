# UpdateAsync

[Back to IUpdatableRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/IUpdatableRepository.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/IUpdatableRepository.cs#L15)

Type: `KamiSama.Chassis.Commons.Repositories.IUpdatableRepository<TEntity>`

Kind: `Method`

## Description

Updates an item in the database. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `TEntity` | `-` | The `entity` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

```csharp
var sample = new SampleEntity { Id = 1, Name = "sample" };
var repository = new InMemoryRepository<SampleEntity>([sample]);

sample.Name = "sample2";

await repository.UpdateAsync(sample, CancellationToken.None);

var retrieved = repository.Find(x => x.Name == "sample2");
```

