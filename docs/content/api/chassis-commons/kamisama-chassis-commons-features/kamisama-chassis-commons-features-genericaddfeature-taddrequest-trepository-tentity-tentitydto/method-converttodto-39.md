# ConvertToDto

[Back to GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericAddFeature.cs:39](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericAddFeature.cs#L39)

Type: `KamiSama.Chassis.Commons.Features.GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>`

Kind: `Method`

## Description

Mapping hook called after the repository add succeeds. Override it to return the DTO shape expected by callers.

## Declaration

```csharp
protected abstract Task<TEntityDto> ConvertToDto(TEntity entity, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `TEntity` | `-` | The entity added by the repository. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntityDto>` | The DTO representation of the entity. |

## Example

```csharp
protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
    => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
```

