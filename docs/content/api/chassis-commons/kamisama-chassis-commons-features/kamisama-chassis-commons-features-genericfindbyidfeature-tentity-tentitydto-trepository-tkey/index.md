# GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>

<a id="genericfindbyidfeature-tentity-tentitydto-trepository-tkey"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons/Features/GenericFindByIdFeature.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericFindByIdFeature.cs#L11)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Class`

## Description

Base implementation for find-by-id use cases. It loads an entity through the repository, throws `NotFoundException<TEntity>` when missing, and maps the entity to a DTO.

## Declaration

```csharp
public abstract class GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>(TRepository repository) :
	IFindByIdFeature<TEntityDto, TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>
```

## Example

```csharp
public sealed class FindProductById(IProductRepository repository)
    : GenericFindByIdFeature<Product, ProductDto, IProductRepository, Guid>(repository)
{
    protected override Task<ProductDto> ConvertToDto(Product entity, CancellationToken cancellationToken)
        => Task.FromResult(new ProductDto(entity.Id, entity.Name, entity.Price));
}
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericFindByIdFeature.cs#L11)

Implements lookup by identifier, missing-entity handling, and entity-to-DTO mapping. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>(TRepository repository) :
	IFindByIdFeature<TEntityDto, TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The repository used by the lookup workflow. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertToDto](method-converttodto-26.md) | Mapping hook called after the entity is found. Override it to return the DTO shape expected by callers. |
| [FindByIdAsync](method-findbyidasync-34.md) | Loads an entity by key through the repository, throws `NotFoundException<TEntity>` when no entity exists, and maps the entity to a DTO. |

### Properties

| Member | Description |
| --- | --- |
| [Repository](property-repository-18.md) | Protected repository used by the find-by-id flow and available to derived mapping code. |

