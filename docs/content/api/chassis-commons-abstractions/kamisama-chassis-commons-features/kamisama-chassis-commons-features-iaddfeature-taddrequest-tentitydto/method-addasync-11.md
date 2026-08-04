# AddAsync

[Back to IAddFeature<TAddRequest, TEntityDto>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IAddFeature.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IAddFeature.cs#L11)

Type: `KamiSama.Chassis.Commons.Features.IAddFeature<TAddRequest, TEntityDto>`

Kind: `Method`

## Description

Runs the `AddAsync` operation on `IAddFeature<TAddRequest, TEntityDto>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<TEntityDto> AddAsync(TAddRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `TAddRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntityDto>` | Returns a `Task<TEntityDto>` value. |

## Example

```csharp
var sample = new SampleEntity { Id = 1, Name = "sample" };
var repository = new InMemoryRepository<SampleEntity>();

await repository.AddAsync(sample, CancellationToken.None);
```

