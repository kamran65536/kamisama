# ListAsync

[Back to GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericListFeature.cs:51](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericListFeature.cs#L51)

Type: `KamiSama.Chassis.Commons.Features.GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>`

Kind: `Method`

## Description

Runs the list flow: request a page from the repository and convert the repository result into the DTO result returned to callers.

## Declaration

```csharp
public virtual async Task<PagedResult<TEntityDto>> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `searchModel` | `TSearchModel` | `-` | The `searchModel` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<PagedResult<TEntityDto>>` | Returns a `Task<PagedResult<TEntityDto>>` value. |

## Example

```csharp
using KamiSama.Extensions.Paging;

var page = await listProductsFeature.ListAsync(SearchModel.FromPage(1, 20), cancellationToken);
```

