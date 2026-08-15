# FindByIdFeatureBase

<a id="findbyidfeaturebase"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/FeatureDefinitionBase.cs:45](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/FeatureDefinitionBase.cs#L45)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Class`

## Description

Nested find-by-id base class from `FeatureDefinitionBase`. Use it for query features that load a single entity by key, throw the package not-found exception when missing, and map the entity to a DTO.

## Declaration

```csharp
public abstract class FindByIdFeatureBase(TRepository repository) : GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>(repository);
```

## Example

```csharp
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

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/FeatureDefinitionBase.cs#L45)

Provides the standard find-by-identifier workflow for the bound feature types. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class FindByIdFeatureBase(TRepository repository) : GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>(repository);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The repository used to find entities. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

