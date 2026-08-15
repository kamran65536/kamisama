# IListingRepository<TEntity, TSearchModel, TPagedResult>

<a id="ilistingrepository-tentity-tsearchmodel-tpagedresult"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/IListingRepository.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/IListingRepository.cs#L9)

Namespace: `KamiSama.Chassis.Commons.Repositories`

Kind: `Interface`

## Description

Defines paged listing and counting with a caller-selected result type. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IListingRepository<TEntity, TSearchModel, TPagedResult>
	where TSearchModel : SearchModel
	where TPagedResult : PagedResult<TEntity>
```

## Example

```csharp
ProductPage page = await products.ListAsync(search, cancellationToken);
int total = await products.CountAsync(search, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [CountAsync](method-countasync-26.md) | Counts entities matching the search criteria. Use it with the surrounding package APIs when composing application code. |
| [ListAsync](method-listasync-19.md) | Searches the store and returns the requested page. Use it with the surrounding package APIs when composing application code. |

