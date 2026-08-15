# GenericRepository<TEntity, TSearchModel, TDbContext>

<a id="genericrepository-tentity-tsearchmodel-tdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Repositories/GenericRepository.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Repositories/GenericRepository.cs#L10)

Namespace: `KamiSama.Chassis.Commons.Repositories`

Kind: `Class`

## Description

Base EF Core repository for paged application repositories. Derive from it when you need the common list/count flow and only want to provide entity-specific search filtering.

## Declaration

```csharp
public abstract class GenericRepository<TEntity, TSearchModel, TDbContext>(TDbContext context) : 
	GenericRepository<TEntity, TSearchModel, TDbContext, PagedResult<TEntity>>(context),
	IGenericRepository<TEntity, TSearchModel>
	where TEntity : class
	where TSearchModel : SearchModel
	where TDbContext : DbContext
```

## Example

```csharp
using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Extensions.Paging;

public sealed class ProductRepository(AppDbContext context)
    : GenericRepository<Product, SearchModel, AppDbContext>(context), IProductRepository
{
    protected override IQueryable<Product> ApplySearchModel(IQueryable<Product> query, SearchModel searchModel)
        => query;
}
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Repositories/GenericRepository.cs#L10)

Provides an EF Core CRUD repository whose standard page result is built with `MakePagedAsync`. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class GenericRepository<TEntity, TSearchModel, TDbContext>(TDbContext context) : 
	GenericRepository<TEntity, TSearchModel, TDbContext, PagedResult<TEntity>>(context),
	IGenericRepository<TEntity, TSearchModel>
	where TEntity : class
	where TSearchModel : SearchModel
	where TDbContext : DbContext
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `TDbContext` | `-` | The context used for CRUD and query operations. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [MakeResultAsync](method-makeresultasync-22.md) | Creates the paged result object after the filtered query is materialized. |

