# AddAsync

[Back to GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericAddFeature.cs:30](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericAddFeature.cs#L30)

Type: `KamiSama.Chassis.Commons.Features.GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>`

Kind: `Method`

## Description

Runs the complete create flow: check duplicates, convert the request to an entity, add it through the repository, convert the saved entity to a DTO, and return it.

## Declaration

```csharp
public virtual async Task<TEntityDto> AddAsync(TAddRequest request, CancellationToken cancellationToken);
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
var dto = await addProductFeature.AddAsync(new AddProductRequest("Keyboard", 120), cancellationToken);
```

