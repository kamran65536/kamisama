# ConvertToDto

[Back to GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericAddFeature.cs:28](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericAddFeature.cs#L28)

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
| `entity` | `TEntity` | `-` | The `entity` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntityDto>` | Returns a `Task<TEntityDto>` value. |

## Example

```csharp
protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
    => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
```

