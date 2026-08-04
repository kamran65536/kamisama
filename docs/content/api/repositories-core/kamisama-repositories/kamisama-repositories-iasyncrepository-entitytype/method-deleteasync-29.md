# DeleteAsync

[Back to IAsyncRepository<_EntityType>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/IAsyncRepository.cs:29](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IAsyncRepository.cs#L29)

Type: `KamiSama.Repositories.IAsyncRepository<_EntityType>`

Kind: `Method`

## Description

Deletes an item from repository. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task DeleteAsync(_EntityType item, CancellationToken cancellation);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `_EntityType` | `-` | The `item` value passed to this member. |
| `cancellation` | `CancellationToken` | `-` | The `cancellation` value passed to this member. |

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

