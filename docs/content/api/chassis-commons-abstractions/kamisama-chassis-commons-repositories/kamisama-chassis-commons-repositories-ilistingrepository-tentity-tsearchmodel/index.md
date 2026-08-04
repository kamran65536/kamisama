# IListingRepository<TEntity, TSearchModel>

<a id="ilistingrepository-tentity-tsearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/IListingRepository.cs:22](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/IListingRepository.cs#L22)

Namespace: `KamiSama.Chassis.Commons.Repositories`

Kind: `Interface`

## Description

A repository with listing capability. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IListingRepository<TEntity, TSearchModel> : IListingRepository<TEntity, TSearchModel, PagedResult<TEntity>>
	where TSearchModel : SearchModel;
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

