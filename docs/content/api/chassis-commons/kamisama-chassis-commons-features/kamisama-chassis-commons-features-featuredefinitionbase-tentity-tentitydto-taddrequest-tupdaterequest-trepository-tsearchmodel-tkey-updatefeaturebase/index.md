# UpdateFeatureBase

<a id="updatefeaturebase"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/FeatureDefinitionBase.cs:35](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/FeatureDefinitionBase.cs#L35)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Class`

## Description

Nested update-flow base class from `FeatureDefinitionBase`. Use it for update features that load an entity by id, optionally check duplicate state, patch the entity from the request, and save through the bound repository.

## Declaration

```csharp
public abstract class UpdateFeatureBase(TRepository repository) : GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>(repository);
```

## Example

```csharp
public sealed class ProductFeatures
    : FeatureDefinitionBase<Product, ProductDto, AddProductRequest, UpdateProductRequest, IProductRepository, SearchModel, Guid>
{
    public sealed class UpdateProduct(IProductRepository repository) : UpdateFeatureBase(repository)
    {
        protected override Task PatchEntityAsync(Product entity, UpdateProductRequest request, CancellationToken cancellationToken)
        {
            entity.Name = request.Name;
            entity.Price = request.Price;
            return Task.CompletedTask;
        }
    }
}
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/FeatureDefinitionBase.cs#L35)

Provides the standard update workflow for the bound feature types. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class UpdateFeatureBase(TRepository repository) : GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>(repository);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The repository used to find and update entities. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

