# KamiSama.Chassis.Commons.Abstractions

[Back to package index](../index.md)

Version: `10.0.10`

## Description

Feature and repository contracts for the KamiSama chassis layer. Reference this package from application or module projects that need to depend on abstractions instead of concrete implementations.

## Install

```shell
dotnet add package KamiSama.Chassis.Commons.Abstractions --version 10.0.10
```

## Namespaces

- [KamiSama.Chassis.Commons.Features](kamisama-chassis-commons-features/index.md) (9 types)
- [KamiSama.Chassis.Commons.Repositories](kamisama-chassis-commons-repositories/index.md) (9 types)

## Types

- [KamiSama.Chassis.Commons.Features.IAddFeature<TAddRequest, TEntityDto>](kamisama-chassis-commons-features/kamisama-chassis-commons-features-iaddfeature-taddrequest-tentitydto/index.md) - Adds an entity from a request. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Features.IDeleteFeature<TKey>](kamisama-chassis-commons-features/kamisama-chassis-commons-features-ideletefeature-tkey/index.md) - Deletes an entity by key feature. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Features.IExistsByIdFeature<TKey>](kamisama-chassis-commons-features/kamisama-chassis-commons-features-iexistsbyidfeature-tkey/index.md) - Defines the contract for `IExistsByIdFeature<TKey>` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.
- [KamiSama.Chassis.Commons.Features.IExistsByNameFeature](kamisama-chassis-commons-features/kamisama-chassis-commons-features-iexistsbynamefeature/index.md) - Defines the contract for `IExistsByNameFeature` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.
- [KamiSama.Chassis.Commons.Features.IFindByIdFeature<TEntityDto, TKey>](kamisama-chassis-commons-features/kamisama-chassis-commons-features-ifindbyidfeature-tentitydto-tkey/index.md) - Defines the contract for `IFindByIdFeature<TEntityDto, TKey>` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.
- [KamiSama.Chassis.Commons.Features.IFindByNameFeature<TEntityDto>](kamisama-chassis-commons-features/kamisama-chassis-commons-features-ifindbynamefeature-tentitydto/index.md) - Defines the contract for `IFindByNameFeature<TEntityDto>` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.
- [KamiSama.Chassis.Commons.Features.IListFeature<TEntityDto, TSearchModel, TPageResult>](kamisama-chassis-commons-features/kamisama-chassis-commons-features-ilistfeature-tentitydto-tsearchmodel-tpageresult/index.md) - Defines the contract for `IListFeature<TEntityDto, TSearchModel, TPageResult>` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.
- [KamiSama.Chassis.Commons.Features.IListFeature<TEntityDto, TSearchModel>](kamisama-chassis-commons-features/kamisama-chassis-commons-features-ilistfeature-tentitydto-tsearchmodel/index.md) - Defines the contract for `IListFeature<TEntityDto, TSearchModel>` behavior. Implement this interface when you need to plug your own code into the surrounding KamiSama package.
- [KamiSama.Chassis.Commons.Features.IUpdateFeature<TEntityDto, TKey>](kamisama-chassis-commons-features/kamisama-chassis-commons-features-iupdatefeature-tentitydto-tkey/index.md) - Updates an entity from the database. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.IAddableRepository<TEntity>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-iaddablerepository-tentity/index.md) - The repository with add capability. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.IDeletableRepository<TEntity>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-ideletablerepository-tentity/index.md) - Repository with Delete feature. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.IGenericRepository<TEntity, TSeaerchModel, TPagedResult>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-igenericrepository-tentity-tseaerchmodel-tpagedresult/index.md) - A common scenario CRUD repository with add, delete, list, update capabilities. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.IGenericRepository<TEntity, TSearchModel>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-igenericrepository-tentity-tsearchmodel/index.md) - A common scenario CRUD repository with add, delete, list, update capabilities. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.IListingRepository<TEntity, TSearchModel, TPagedResult>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-ilistingrepository-tentity-tsearchmodel-tpagedresult/index.md) - A repository with listing capability. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.IListingRepository<TEntity, TSearchModel>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-ilistingrepository-tentity-tsearchmodel/index.md) - A repository with listing capability. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.ILookupByIdRepository<TEntity, TKey>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-ilookupbyidrepository-tentity-tkey/index.md) - Repository with find by Id feature. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.ILookupByNameRepository<TEntity>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-ilookupbynamerepository-tentity/index.md) - Repository with find by name feature. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Chassis.Commons.Repositories.IUpdatableRepository<TEntity>](kamisama-chassis-commons-repositories/kamisama-chassis-commons-repositories-iupdatablerepository-tentity/index.md) - Repository with update capability. Use it with the surrounding package APIs when composing application code.
