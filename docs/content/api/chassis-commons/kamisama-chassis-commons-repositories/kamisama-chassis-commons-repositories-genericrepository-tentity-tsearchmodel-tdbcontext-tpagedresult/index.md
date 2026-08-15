# GenericRepository<TEntity, TSearchModel, TDbContext, TPagedResult>

<a id="genericrepository-tentity-tsearchmodel-tdbcontext-tpagedresult"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Repositories/GenericRepository.cs:33](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Repositories/GenericRepository.cs#L33)

Namespace: `KamiSama.Chassis.Commons.Repositories`

Kind: `Class`

## Description

Base EF Core repository for paged application repositories. Derive from it when you need the common list/count flow and only want to provide entity-specific search filtering.

## Declaration

```csharp
public abstract class GenericRepository<TEntity, TSearchModel, TDbContext, TPagedResult>(TDbContext context) :
	DbRepository<TEntity, TDbContext>(context),
	IGenericRepository<TEntity, TSearchModel, TPagedResult>
	where TEntity : class
	where TSearchModel : SearchModel
	where TDbContext : DbContext
	where TPagedResult : PagedResult<TEntity>
```

## Example

```csharp
public sealed class ProductRepository(AppDbContext context)
    : GenericRepository<Product, ProductSearch, AppDbContext, ProductPage>(context)
{
    protected override IQueryable<Product> ApplySearchModel(IQueryable<Product> query, ProductSearch search)
        => string.IsNullOrWhiteSpace(search.Name) ? query : query.Where(product => product.Name.Contains(search.Name));

    protected override async Task<ProductPage> MakeResultAsync(IQueryable<Product> query, ProductSearch search, CancellationToken cancellationToken)
        => await ProductPage.CreateAsync(query, search, cancellationToken);
}
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Repositories/GenericRepository.cs#L33)

Provides EF Core CRUD, filtered listing, and counting with a custom page result type. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class GenericRepository<TEntity, TSearchModel, TDbContext, TPagedResult>(TDbContext context) :
	DbRepository<TEntity, TDbContext>(context),
	IGenericRepository<TEntity, TSearchModel, TPagedResult>
	where TEntity : class
	where TSearchModel : SearchModel
	where TDbContext : DbContext
	where TPagedResult : PagedResult<TEntity>
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `TDbContext` | `-` | The context used for CRUD and query operations. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplySearchModel](method-applysearchmodel-47.md) | Filtering hook called before list/count results are materialized. Override it to apply search criteria, ordering, and any entity-specific query conditions. |
| [CountAsync](method-countasync-73.md) | Applies the search model and returns the total matching entity count. |
| [ListAsync](method-listasync-61.md) | Applies the search model and returns a paged repository result. |
| [MakeResultAsync](method-makeresultasync-55.md) | Creates the paged result object after the filtered query is materialized. |

