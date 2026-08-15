# KamiSama.Chassis.Commons.Abstractions

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Feature and repository contracts for the KamiSama chassis layer. Reference this package from application or module projects that need to depend on abstractions instead of concrete implementations.

## How to use

```shell
dotnet add package KamiSama.Chassis.Commons.Abstractions --version 10.0.0
```

Reference this package from contracts, callers, and implementations that need shared CRUD feature or repository shapes without taking a dependency on the concrete chassis workflows:

```csharp
using KamiSama.Chassis.Commons.Features;

public sealed class ProductController(IFindByIdFeature<ProductDto, Guid> findProduct)
{
    public Task<ProductDto> Get(Guid id, CancellationToken cancellationToken)
        => findProduct.FindByIdAsync(id, cancellationToken);
}
```

This package contains contracts only: it does not register services, implement persistence, define transaction boundaries, or decide missing-entity behavior. The shorter `IListFeature<TEntityDto, TSearchModel>`, `IListingRepository<TEntity, TSearchModel>`, and `IGenericRepository<TEntity, TSearchModel>` interfaces are aliases for the standard `PagedResult<T>` shapes.

## Namespaces

- [KamiSama.Chassis.Commons.Features](kamisama-chassis-commons-features/index.md) (9 types)
- [KamiSama.Chassis.Commons.Repositories](kamisama-chassis-commons-repositories/index.md) (9 types)

## Types

- [KamiSama.Chassis.Commons.Features.IAddFeature<TAddRequest, TEntityDto>](kamisama-chassis-commons-features/kamisama-chassis-commons-features-iaddfeature-taddrequest-tentitydto/index.md) - Defines a create use case that accepts a request and returns the created entity DTO. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Features.IDeleteFeature<TKey>](kamisama-chassis-commons-features/kamisama-chassis-commons-features-ideletefeature-tkey/index.md) - Defines a use case that deletes an entity identified by a key. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Features.IExistsByIdFeature<TKey>](kamisama-chassis-commons-features/kamisama-chassis-commons-features-iexistsbyidfeature-tkey/index.md) - Defines an existence check for an entity identifier. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Features.IExistsByNameFeature](kamisama-chassis-commons-features/kamisama-chassis-commons-features-iexistsbynamefeature/index.md) - Defines an existence check for an entity name. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Features.IFindByIdFeature<TEntityDto, TKey>](kamisama-chassis-commons-features/kamisama-chassis-commons-features-ifindbyidfeature-tentitydto-tkey/index.md) - Defines a query that returns one entity DTO by identifier. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Features.IFindByNameFeature<TEntityDto>](kamisama-chassis-commons-features/kamisama-chassis-commons-features-ifindbynamefeature-tentitydto/index.md) - Defines a query that returns one entity DTO by name. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Features.IListFeature<TEntityDto, TSearchModel, TPageResult>](kamisama-chassis-commons-features/kamisama-chassis-commons-features-ilistfeature-tentitydto-tsearchmodel-tpageresult/index.md) - Defines a paged list query with a caller-selected result type. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Features.IListFeature<TEntityDto, TSearchModel>](kamisama-chassis-commons-features/kamisama-chassis-commons-features-ilistfeature-tentitydto-tsearchmodel/index.md) - Defines a paged list query that returns the standard `PagedResult{T}` shape. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Features.IUpdateFeature<TEntityDto, TKey>](kamisama-chassis-commons-features/kamisama-chassis-commons-features-iupdatefeature-tentitydto-tkey/index.md) - Defines an update use case for an entity identified by a key. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.IAddableRepository<TEntity>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-iaddablerepository-tentity/index.md) - Defines persistence of new entities. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.IDeletableRepository<TEntity>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-ideletablerepository-tentity/index.md) - Defines deletion of persisted entities. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.IGenericRepository<TEntity, TSeaerchModel, TPagedResult>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-igenericrepository-tentity-tseaerchmodel-tpagedresult/index.md) - Combines add, update, delete, and paged-list repository capabilities with a custom page result. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.IGenericRepository<TEntity, TSearchModel>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-igenericrepository-tentity-tsearchmodel/index.md) - Combines add, update, delete, and paged-list repository capabilities using the standard page result. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.IListingRepository<TEntity, TSearchModel, TPagedResult>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-ilistingrepository-tentity-tsearchmodel-tpagedresult/index.md) - Defines paged listing and counting with a caller-selected result type. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.IListingRepository<TEntity, TSearchModel>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-ilistingrepository-tentity-tsearchmodel/index.md) - Defines paged listing and counting using the standard `PagedResult{T}` shape. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.ILookupByIdRepository<TEntity, TKey>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-ilookupbyidrepository-tentity-tkey/index.md) - Defines lookup and existence checks by entity identifier. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.ILookupByNameRepository<TEntity>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-ilookupbynamerepository-tentity/index.md) - Defines lookup and existence checks by entity name. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.IUpdatableRepository<TEntity>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-iupdatablerepository-tentity/index.md) - Defines persistence of changes to existing entities. Use it with the surrounding package APIs when composing application code.
