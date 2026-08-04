# DeleteAsync

[Back to IDeletableRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/IDeletableRepository.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/IDeletableRepository.cs#L15)

Type: `KamiSama.Chassis.Commons.Repositories.IDeletableRepository<TEntity>`

Kind: `Method`

## Description

Deletes an item from the database. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
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
var entity = new SampleEntity { Id = 1, Name = "Test" };
var context = GetDbContext(initialDbSet: [entity]);

var repository = new DbRepository<SampleEntity>(context);

await repository.DeleteAsync(entity, CancellationToken.None);
```

