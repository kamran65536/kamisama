# IQueryableExtensions

<a id="iqueryableextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Core/IQueryableExtensions.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/IQueryableExtensions.cs#L9)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Provides extensions for materializing `IQueryable{T}` sequences as paged results. Use them after applying filtering and ordering to a query.

## Declaration

```csharp
public static class IQueryableExtensions
```

## Example

```csharp
using KamiSama.Extensions.Paging;

IQueryable<string> query = new[] { "one", "two", "three" }.AsQueryable();
PagedResult<string> page = query.MakePaged(SearchModel.FromPage(1, 2));
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [MakePaged<T>](method-makepaged-t-18.md) | Counts and materializes the requested page of the query, or all items when the page size is zero. Use it with the surrounding package APIs when composing application code. |

