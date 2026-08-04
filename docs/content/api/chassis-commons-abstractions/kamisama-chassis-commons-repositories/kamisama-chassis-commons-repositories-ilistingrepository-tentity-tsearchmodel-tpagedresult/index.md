# IListingRepository<TEntity, TSearchModel, TPagedResult>

<a id="ilistingrepository-tentity-tsearchmodel-tpagedresult"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/IListingRepository.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/IListingRepository.cs#L6)

Namespace: `KamiSama.Chassis.Commons.Repositories`

Kind: `Interface`

## Description

A repository with listing capability. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IListingRepository<TEntity, TSearchModel, TPagedResult>
	where TSearchModel : SearchModel
	where TPagedResult : PagedResult<TEntity>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [CountAsync](method-countasync-17.md) | Counts the item based on the search model. Use it with the surrounding package APIs when composing application code. |
| [ListAsync](method-listasync-13.md) | Lists items and page them. Use it with the surrounding package APIs when composing application code. |

