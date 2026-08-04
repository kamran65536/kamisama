# DeleteAsync

[Back to IDeleteFeature<TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IDeleteFeature.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IDeleteFeature.cs#L11)

Type: `KamiSama.Chassis.Commons.Features.IDeleteFeature<TKey>`

Kind: `Method`

## Description

Runs the `DeleteAsync` operation on `IDeleteFeature<TKey>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task DeleteAsync(TKey key, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `key` | `TKey` | `-` | The `key` value passed to this member. |
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

