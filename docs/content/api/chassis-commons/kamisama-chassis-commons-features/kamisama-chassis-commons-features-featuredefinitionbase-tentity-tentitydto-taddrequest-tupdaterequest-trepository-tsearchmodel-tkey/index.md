# FeatureDefinitionBase<TEntity, TEntityDto, TAddRequest, TUpdateRequest, TRepository, TSearchModel, TKey>

<a id="featuredefinitionbase-tentity-tentitydto-taddrequest-tupdaterequest-trepository-tsearchmodel-tkey"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/FeatureDefinitionBase.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/FeatureDefinitionBase.cs#L17)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Class`

## Description

Binds the entity, DTO, add request, update request, repository, search model, and key types once for a CRUD-style feature set. Use it as a typed shell when several features in the same module work over the same entity and repository.

## Declaration

```csharp
public class FeatureDefinitionBase<TEntity, TEntityDto, TAddRequest, TUpdateRequest, TRepository, TSearchModel, TKey>
	where TSearchModel : SearchModel
	where TRepository : IGenericRepository<TEntity, TSearchModel>, ILookupByIdRepository<TEntity, TKey>
```

## Example

```csharp
using KamiSama.Chassis.Commons.Features;
using KamiSama.Extensions.Paging;

public sealed class ProductFeatures
    : FeatureDefinitionBase<Product, ProductDto, AddProductRequest, UpdateProductRequest, IProductRepository, SearchModel, Guid>
{
    public sealed class FindProduct(IProductRepository repository) : FindByIdFeatureBase(repository)
    {
        protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
            => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
    }
}
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

