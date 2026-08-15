# IListFeature<TEntityDto, TSearchModel, TPageResult>

<a id="ilistfeature-tentitydto-tsearchmodel-tpageresult"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IListFeature.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IListFeature.cs#L9)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Interface`

## Description

Defines a paged list query with a caller-selected result type. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IListFeature<TEntityDto, TSearchModel, TPageResult>
	where TSearchModel : SearchModel
	where TPageResult : PagedResult<TEntityDto>
```

## Example

```csharp
ProductPage page = await listProducts.ListAsync(
    new ProductSearch { PageNumber = 1, PageSize = 20 }, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ListAsync](method-listasync-19.md) | Searches for matching items and returns the requested page. Use it with the surrounding package APIs when composing application code. |

