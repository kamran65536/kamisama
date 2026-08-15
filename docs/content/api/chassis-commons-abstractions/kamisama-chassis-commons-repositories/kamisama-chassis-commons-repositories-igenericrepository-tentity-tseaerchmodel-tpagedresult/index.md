# IGenericRepository<TEntity, TSeaerchModel, TPagedResult>

<a id="igenericrepository-tentity-tseaerchmodel-tpagedresult"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/IGenericRepository.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/IGenericRepository.cs#L11)

Namespace: `KamiSama.Chassis.Commons.Repositories`

Kind: `Interface`

## Description

Combines add, update, delete, and paged-list repository capabilities with a custom page result. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IGenericRepository<TEntity, TSeaerchModel, TPagedResult>
	: IAddableRepository<TEntity>, IUpdatableRepository<TEntity>, IDeletableRepository<TEntity>, IListingRepository<TEntity, TSeaerchModel, TPagedResult>
	where TSeaerchModel : SearchModel
	where TPagedResult : PagedResult<TEntity>
```

## Example

```csharp
public interface IProductRepository
    : IGenericRepository<Product, ProductSearch, ProductPage>,
      ILookupByIdRepository<Product, Guid>
{
}
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

