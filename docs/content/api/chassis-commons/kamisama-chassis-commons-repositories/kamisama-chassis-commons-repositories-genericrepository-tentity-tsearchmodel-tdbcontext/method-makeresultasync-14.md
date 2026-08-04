# MakeResultAsync

[Back to GenericRepository<TEntity, TSearchModel, TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Repositories/GenericRepository.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Repositories/GenericRepository.cs#L14)

Type: `KamiSama.Chassis.Commons.Repositories.GenericRepository<TEntity, TSearchModel, TDbContext>`

Kind: `Method`

## Description

Creates the paged result object after the filtered query is materialized.

## Declaration

```csharp
protected override Task<PagedResult<TEntity>> MakeResultAsync(IQueryable<TEntity> query, TSearchModel searchModel, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `query` | `IQueryable<TEntity>` | `-` | The `query` value passed to this member. |
| `searchModel` | `TSearchModel` | `-` | The `searchModel` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<PagedResult<TEntity>>` | Returns a `Task<PagedResult<TEntity>>` value. |

## Example

No concise standalone example is available yet.

