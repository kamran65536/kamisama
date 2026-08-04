# ListFeatureBase

<a id="listfeaturebase"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/FeatureDefinitionBase.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/FeatureDefinitionBase.cs#L17)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Class`

## Description

Nested list-flow base class from `FeatureDefinitionBase`. Use it for paged list features that read a repository page and map each entity to the DTO type bound by the feature definition.

## Declaration

```csharp
public abstract class ListFeatureBase(TRepository repository) : GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>(repository);
```

## Example

```csharp
public sealed class ProductFeatures
    : FeatureDefinitionBase<Product, ProductDto, AddProductRequest, UpdateProductRequest, IProductRepository, SearchModel, Guid>
{
    public sealed class ListProducts(IProductRepository repository) : ListFeatureBase(repository)
    {
        protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
            => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
    }
}
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/FeatureDefinitionBase.cs#L17)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class ListFeatureBase(TRepository repository) : GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>(repository);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The `repository` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

