# DeleteFeatureBase

<a id="deletefeaturebase"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/FeatureDefinitionBase.cs:29](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/FeatureDefinitionBase.cs#L29)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Class`

## Description

Nested delete-flow base class from `FeatureDefinitionBase`. Use it for delete features that load an entity by id, optionally check whether deletion is allowed, and delete through the bound repository.

## Declaration

```csharp
public abstract class DeleteFeatureBase(TRepository repository) :  GenericDeleteFeature<TEntity, TRepository, TKey>(repository);
```

## Example

```csharp
public sealed class ProductFeatures
    : FeatureDefinitionBase<Product, ProductDto, AddProductRequest, UpdateProductRequest, IProductRepository, SearchModel, Guid>
{
    public sealed class DeleteProduct(IProductRepository repository) : DeleteFeatureBase(repository)
    {
        protected override Task<bool> CanBeDeletedAsync(IProductRepository repository, Product entity)
            => Task.FromResult(!entity.HasOpenOrders);
    }
}
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/FeatureDefinitionBase.cs#L29)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class DeleteFeatureBase(TRepository repository) :  GenericDeleteFeature<TEntity, TRepository, TKey>(repository);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The `repository` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

