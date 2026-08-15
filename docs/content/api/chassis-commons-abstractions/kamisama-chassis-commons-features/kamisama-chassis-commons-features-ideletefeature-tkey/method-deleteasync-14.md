# DeleteAsync

[Back to IDeleteFeature<TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IDeleteFeature.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IDeleteFeature.cs#L14)

Type: `KamiSama.Chassis.Commons.Features.IDeleteFeature<TKey>`

Kind: `Method`

## Description

Deletes the entity identified by the supplied key. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task DeleteAsync(TKey key, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `key` | `TKey` | `-` | The key of the entity to delete. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents the asynchronous deletion. |

## Example

```csharp
var entity = new SampleEntity { Id = 1, Name = "Test" };
var context = GetDbContext(initialDbSet: [entity]);

var repository = new DbRepository<SampleEntity>(context);

await repository.DeleteAsync(entity, CancellationToken.None);
```

