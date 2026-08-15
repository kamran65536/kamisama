# GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>

<a id="genericlistfeature-tentity-tentitydto-tsearchmodel-trepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/GenericListFeature.cs:50](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericListFeature.cs#L50)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Class`

## Description

Base implementation for paged list use cases. It delegates paging to the repository and maps repository entities into the DTO result shape expected by callers.

## Declaration

```csharp
public abstract class GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>(TRepository repository) :
	IListFeature<TEntityDto, TSearchModel>
	where TRepository : IListingRepository<TEntity, TSearchModel>
	where TSearchModel : SearchModel
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

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericListFeature.cs#L50)

Implements a paged list workflow using standard `PagedResult{T}` result shapes. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>(TRepository repository) :
	IListFeature<TEntityDto, TSearchModel>
	where TRepository : IListingRepository<TEntity, TSearchModel>
	where TSearchModel : SearchModel
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The repository used by the list workflow. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertToDto](method-converttodto-65.md) | Mapping hook called for each entity in the repository page. Override it to produce the DTO returned to callers. |
| [ConvertToPagedResultAsync](method-converttopagedresultasync-72.md) | Result-shaping hook that converts a repository `PagedResult<TEntity>` into a `PagedResult<TEntityDto>`. Override it only when the default item-by-item DTO mapping is not enough. |
| [ListAsync](method-listasync-78.md) | Runs the list flow: request a page from the repository and convert the repository result into the DTO result returned to callers. |

### Properties

| Member | Description |
| --- | --- |
| [Repository](property-repository-58.md) | Protected repository used by derived list features. The base list flow delegates paging to this repository. |

