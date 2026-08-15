# AddAsync

[Back to IAddFeature<TAddRequest, TEntityDto>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IAddFeature.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IAddFeature.cs#L16)

Type: `KamiSama.Chassis.Commons.Features.IAddFeature<TAddRequest, TEntityDto>`

Kind: `Method`

## Description

Creates an entity from the request and returns its DTO representation. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<TEntityDto> AddAsync(TAddRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `TAddRequest` | `-` | The values used to create the entity. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntityDto>` | The DTO produced for the created entity. |

## Example

```csharp
var sample = new SampleEntity { Id = 1, Name = "sample" };
var repository = new InMemoryRepository<SampleEntity>();

await repository.AddAsync(sample, CancellationToken.None);
```

