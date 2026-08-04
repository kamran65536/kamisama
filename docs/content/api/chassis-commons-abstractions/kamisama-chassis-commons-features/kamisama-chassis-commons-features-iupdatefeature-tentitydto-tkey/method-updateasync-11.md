# UpdateAsync

[Back to IUpdateFeature<TEntityDto, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IUpdateFeature.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IUpdateFeature.cs#L11)

Type: `KamiSama.Chassis.Commons.Features.IUpdateFeature<TEntityDto, TKey>`

Kind: `Method`

## Description

Runs the `UpdateAsync` operation on `IUpdateFeature<TEntityDto, TKey>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task UpdateAsync(TKey key, TEntityDto dto, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `key` | `TKey` | `-` | The `key` value passed to this member. |
| `dto` | `TEntityDto` | `-` | The `dto` value passed to this member. |
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

