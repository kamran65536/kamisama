# AddAsync

[Back to GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericAddFeature.cs:44](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericAddFeature.cs#L44)

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
| `request` | `TAddRequest` | `-` | The values used to create the entity. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntityDto>` | The DTO produced from the added entity. |

## Example

```csharp
var dto = await addProductFeature.AddAsync(new AddProductRequest("Keyboard", 120), cancellationToken);
```

