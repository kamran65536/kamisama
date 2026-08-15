# AddAsync

[Back to IAddableRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/IAddableRepository.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/IAddableRepository.cs#L15)

Type: `KamiSama.Chassis.Commons.Repositories.IAddableRepository<TEntity>`

Kind: `Method`

## Description

Adds an entity to the underlying store. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task AddAsync(TEntity entity, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `TEntity` | `-` | The entity to add. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents the asynchronous add. |

## Example

```csharp
var sample = new SampleEntity { Id = 1, Name = "sample" };
var repository = new InMemoryRepository<SampleEntity>();

await repository.AddAsync(sample, CancellationToken.None);
```

