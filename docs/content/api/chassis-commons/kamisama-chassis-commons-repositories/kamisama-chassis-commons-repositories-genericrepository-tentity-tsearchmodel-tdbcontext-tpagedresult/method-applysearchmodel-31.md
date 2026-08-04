# ApplySearchModel

[Back to GenericRepository<TEntity, TSearchModel, TDbContext, TPagedResult>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Repositories/GenericRepository.cs:31](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Repositories/GenericRepository.cs#L31)

Type: `KamiSama.Chassis.Commons.Repositories.GenericRepository<TEntity, TSearchModel, TDbContext, TPagedResult>`

Kind: `Method`

## Description

Filtering hook called before list/count results are materialized. Override it to apply search criteria, ordering, and any entity-specific query conditions.

## Declaration

```csharp
protected abstract IQueryable<TEntity> ApplySearchModel(IQueryable<TEntity> query, TSearchModel searchModel);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `query` | `IQueryable<TEntity>` | `-` | The `query` value passed to this member. |
| `searchModel` | `TSearchModel` | `-` | The `searchModel` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `IQueryable<TEntity>` | Returns a `IQueryable<TEntity>` value. |

## Example

No concise standalone example is available yet.

