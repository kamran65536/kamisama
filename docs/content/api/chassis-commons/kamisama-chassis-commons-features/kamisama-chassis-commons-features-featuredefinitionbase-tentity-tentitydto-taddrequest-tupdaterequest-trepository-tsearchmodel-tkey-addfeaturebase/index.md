# AddFeatureBase

<a id="addfeaturebase"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/FeatureDefinitionBase.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/FeatureDefinitionBase.cs#L21)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Class`

## Description

Nested create-flow base class from `FeatureDefinitionBase`. Use it after the feature definition has already bound the entity, DTO, add-request, repository, search-model, and key types, so each concrete add feature only implements duplicate checking and mapping.

## Declaration

```csharp
public abstract class AddFeatureBase(TRepository repository) : GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>(repository);
```

## Example

```csharp
using KamiSama.Chassis.Commons.Features;
using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Chassis.HttpExceptions;
using KamiSama.Extensions.Paging;

public sealed record AddProductRequest(string Name, decimal Price);
public sealed record UpdateProductRequest(string Name, decimal Price);
public sealed record ProductDto(Guid Id, string Name, decimal Price);
public sealed class Product { public Guid Id { get; set; } public string Name { get; set; } = ""; public decimal Price { get; set; } }

public interface IProductRepository :
    IGenericRepository<Product, SearchModel>,
    ILookupByIdRepository<Product, Guid>,
    ILookupByNameRepository<Product>
{
}

public sealed class ProductFeatures
    : FeatureDefinitionBase<Product, ProductDto, AddProductRequest, UpdateProductRequest, IProductRepository, SearchModel, Guid>
{
    public sealed class AddProduct(IProductRepository repository) : AddFeatureBase(repository)
    {
        protected override async Task CheckDuplicateAsync(AddProductRequest request, CancellationToken cancellationToken)
        {
            if (await Repository.ExistsByNameAsync(request.Name, cancellationToken))
                throw new AlreadyExistsException<Product>(request.Name, nameof(request.Name));
        }

        protected override Task<Product> ConvertToEntity(AddProductRequest request, CancellationToken cancellationToken)
            => Task.FromResult(new Product { Id = Guid.NewGuid(), Name = request.Name, Price = request.Price });

        protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
            => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
    }
}
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/FeatureDefinitionBase.cs#L21)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class AddFeatureBase(TRepository repository) : GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>(repository);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The `repository` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

