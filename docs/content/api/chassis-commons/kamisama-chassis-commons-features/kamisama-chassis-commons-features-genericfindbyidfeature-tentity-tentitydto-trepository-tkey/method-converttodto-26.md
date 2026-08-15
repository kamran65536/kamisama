# ConvertToDto

[Back to GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericFindByIdFeature.cs:26](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericFindByIdFeature.cs#L26)

Type: `KamiSama.Chassis.Commons.Features.GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>`

Kind: `Method`

## Description

Mapping hook called after the entity is found. Override it to return the DTO shape expected by callers.

## Declaration

```csharp
protected abstract Task<TEntityDto> ConvertToDto(TEntity entity, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `TEntity` | `-` | The entity loaded from the repository. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the mapping operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntityDto>` | The DTO representation of the entity. |

## Example

```csharp
protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
    => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
```

