# ListAsync

[Back to GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository, TPagedResult, TRepositoryPagedResult>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericListFeature.cs:35](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericListFeature.cs#L35)

Type: `KamiSama.Chassis.Commons.Features.GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository, TPagedResult, TRepositoryPagedResult>`

Kind: `Method`

## Description

Runs the list flow: request a page from the repository and convert the repository result into the DTO result returned to callers.

## Declaration

```csharp
public virtual async Task<TPagedResult> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `searchModel` | `TSearchModel` | `-` | The filtering and paging values. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TPagedResult>` | A converted page of matching DTOs. |

## Example

```csharp
using KamiSama.Extensions.Paging;

var page = await listProductsFeature.ListAsync(SearchModel.FromPage(1, 20), cancellationToken);
```

