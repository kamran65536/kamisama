# ConvertToDto

[Back to GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericListFeature.cs:65](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericListFeature.cs#L65)

Type: `KamiSama.Chassis.Commons.Features.GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>`

Kind: `Method`

## Description

Mapping hook called for each entity in the repository page. Override it to produce the DTO returned to callers.

## Declaration

```csharp
protected abstract Task<TEntityDto> ConvertToDto(TEntity entity, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `TEntity` | `-` | The repository entity to convert. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the conversion. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntityDto>` | The DTO representation of the entity. |

## Example

```csharp
protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
    => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
```

