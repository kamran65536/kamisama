# IGenericRepository<TEntity, TSearchModel>

<a id="igenericrepository-tentity-tsearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/IGenericRepository.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/IGenericRepository.cs#L17)

Namespace: `KamiSama.Chassis.Commons.Repositories`

Kind: `Interface`

## Description

A common scenario CRUD repository with add, delete, list, update capabilities. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IGenericRepository<TEntity, TSearchModel>: 
	IGenericRepository<TEntity, TSearchModel, PagedResult<TEntity>>,
	IListingRepository<TEntity, TSearchModel>
	where TSearchModel : SearchModel
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

