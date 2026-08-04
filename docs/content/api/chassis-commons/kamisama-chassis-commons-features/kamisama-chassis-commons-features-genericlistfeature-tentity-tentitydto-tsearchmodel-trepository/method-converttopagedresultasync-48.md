# ConvertToPagedResultAsync

[Back to GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericListFeature.cs:48](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericListFeature.cs#L48)

Type: `KamiSama.Chassis.Commons.Features.GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>`

Kind: `Method`

## Description

Result-shaping hook that converts a repository `PagedResult<TEntity>` into a `PagedResult<TEntityDto>`. Override it only when the default item-by-item DTO mapping is not enough.

## Declaration

```csharp
protected virtual Task<PagedResult<TEntityDto>> ConvertToPagedResultAsync(PagedResult<TEntity> result, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `result` | `PagedResult<TEntity>` | `-` | The `result` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<PagedResult<TEntityDto>>` | Returns a `Task<PagedResult<TEntityDto>>` value. |

## Example

```csharp
protected override Task<PagedResult<ProductDto>> ConvertToPagedResultAsync(PagedResult<Product> result, CancellationToken cancellationToken)
    => result.ConvertToAsync(ConvertToDto, cancellationToken);
```

