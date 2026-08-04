# GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>

<a id="genericaddfeature-taddrequest-trepository-tentity-tentitydto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/GenericAddFeature.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericAddFeature.cs#L6)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Class`

## Description

Base implementation for create use cases. `AddAsync` checks duplicate state, converts the request to an entity, persists it through the repository, and returns a DTO.

## Declaration

```csharp
public abstract class GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>(TRepository repository) : 
	IAddFeature<TAddRequest, TEntityDto>
	where TRepository : IAddableRepository<TEntity>
```

## Example

```csharp
using KamiSama.Chassis.Commons.Features;
using KamiSama.Chassis.HttpExceptions;

public sealed class AddProductFeature(IProductRepository repository)
    : GenericAddFeature<AddProductRequest, IProductRepository, Product, ProductDto>(repository)
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
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericAddFeature.cs#L6)

Generic implementation of `IAddFeature{TAddRequest, TEntityDto}`. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>(TRepository repository) : 
	IAddFeature<TAddRequest, TEntityDto>
	where TRepository : IAddableRepository<TEntity>
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The `repository` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddAsync](method-addasync-30.md) | Runs the complete create flow: check duplicates, convert the request to an entity, add it through the repository, convert the saved entity to a DTO, and return it. |
| [CheckDuplicateAsync](method-checkduplicateasync-17.md) | Validation hook called at the start of `AddAsync`. Override it to detect duplicate or conflicting data and throw a domain or HTTP exception before the entity is created. |
| [ConvertToDto](method-converttodto-28.md) | Mapping hook called after the repository add succeeds. Override it to return the DTO shape expected by callers. |
| [ConvertToEntity](method-converttoentity-21.md) | Mapping hook called after duplicate validation. Override it to create the entity that will be persisted from the incoming add request. |

### Properties

| Member | Description |
| --- | --- |
| [Repository](property-repository-13.md) | Protected repository used by derived feature implementations. Use it inside mapping and validation hooks when the feature needs data access beyond the base add flow. |

