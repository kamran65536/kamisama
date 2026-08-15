# ExistsByIdFeatureBase

<a id="existsbyidfeaturebase"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/FeatureDefinitionBase.cs:50](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/FeatureDefinitionBase.cs#L50)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Class`

## Description

Nested exists-by-id base class from `FeatureDefinitionBase`. Use it for simple features that expose repository existence checks through an application feature interface.

## Declaration

```csharp
public abstract class ExistsByIdFeatureBase(TRepository repository) : GenericExistsByIdFeature<TEntity, TRepository, TKey>(repository);
```

## Example

```csharp
public sealed class ProductFeatures
    : FeatureDefinitionBase<Product, ProductDto, AddProductRequest, UpdateProductRequest, IProductRepository, SearchModel, Guid>
{
    public sealed class ProductExists(IProductRepository repository) : ExistsByIdFeatureBase(repository);
}
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/FeatureDefinitionBase.cs#L50)

Provides the standard exists-by-identifier workflow for the bound feature types. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class ExistsByIdFeatureBase(TRepository repository) : GenericExistsByIdFeature<TEntity, TRepository, TKey>(repository);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The repository used for existence checks. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

