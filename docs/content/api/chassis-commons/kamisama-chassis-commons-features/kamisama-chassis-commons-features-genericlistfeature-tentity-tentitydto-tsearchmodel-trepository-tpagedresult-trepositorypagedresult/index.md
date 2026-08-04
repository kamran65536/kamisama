# GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository, TPagedResult, TRepositoryPagedResult>

<a id="genericlistfeature-tentity-tentitydto-tsearchmodel-trepository-tpagedresult-trepositorypagedresult"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/GenericListFeature.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericListFeature.cs#L6)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Class`

## Description

Base implementation for paged list use cases. It delegates paging to the repository and maps repository entities into the DTO result shape expected by callers.

## Declaration

```csharp
public abstract class GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository, TPagedResult, TRepositoryPagedResult>(TRepository repository) :
	IListFeature<TEntityDto, TSearchModel, TPagedResult>
	where TRepository : IListingRepository<TEntity, TSearchModel, TRepositoryPagedResult>
	where TSearchModel : SearchModel
	where TPagedResult : PagedResult<TEntityDto>
	where TRepositoryPagedResult : PagedResult<TEntity>
```

## Example

```csharp
using KamiSama.Extensions.Paging;

public sealed class ListProductsFeature(IProductRepository repository)
    : GenericListFeature<Product, ProductDto, SearchModel, IProductRepository>(repository)
{
    protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
        => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
}
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericListFeature.cs#L6)

Generic implementation of `IListFeature{TEntityDto, TSearchModel}`. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository, TPagedResult, TRepositoryPagedResult>(TRepository repository) :
	IListFeature<TEntityDto, TSearchModel, TPagedResult>
	where TRepository : IListingRepository<TEntity, TSearchModel, TRepositoryPagedResult>
	where TSearchModel : SearchModel
	where TPagedResult : PagedResult<TEntityDto>
	where TRepositoryPagedResult : PagedResult<TEntity>
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The `repository` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertResult](method-convertresult-20.md) | Result-shaping hook for custom paged result types. Override it to translate the repository result into the result type exposed by the feature. |
| [ListAsync](method-listasync-22.md) | Runs the list flow: request a page from the repository and convert the repository result into the DTO result returned to callers. |

### Properties

| Member | Description |
| --- | --- |
| [Repository](property-repository-16.md) | Protected repository used by derived list features. The base list flow delegates paging to this repository. |

