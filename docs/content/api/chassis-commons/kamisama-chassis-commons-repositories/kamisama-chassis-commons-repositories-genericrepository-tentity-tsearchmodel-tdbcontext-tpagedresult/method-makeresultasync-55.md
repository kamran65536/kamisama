# MakeResultAsync

[Back to GenericRepository<TEntity, TSearchModel, TDbContext, TPagedResult>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Repositories/GenericRepository.cs:55](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Repositories/GenericRepository.cs#L55)

Type: `KamiSama.Chassis.Commons.Repositories.GenericRepository<TEntity, TSearchModel, TDbContext, TPagedResult>`

Kind: `Method`

## Description

Creates the paged result object after the filtered query is materialized.

## Declaration

```csharp
protected abstract Task<TPagedResult> MakeResultAsync(IQueryable<TEntity> query, TSearchModel searchModel, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `query` | `IQueryable<TEntity>` | `-` | The filtered entity query. |
| `searchModel` | `TSearchModel` | `-` | The paging values. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel query execution. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TPagedResult>` | The materialized custom page result. |

## Example

No concise standalone example is available yet.

