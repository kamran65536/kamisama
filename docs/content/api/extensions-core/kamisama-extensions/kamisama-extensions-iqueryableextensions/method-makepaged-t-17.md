# MakePaged<T>

[Back to IQueryableExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/IQueryableExtensions.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/IQueryableExtensions.cs#L17)

Type: `KamiSama.Extensions.IQueryableExtensions`

Kind: `Method`

## Description

Makes the query paged, used for user interface and apis paging. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static PagedResult<T> MakePaged<T>(this IQueryable<T> query, SearchModel searchModel);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `T` |  |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `query (extension receiver)` | `IQueryable<T>` | `-` | The `query` value passed to this member. |
| `searchModel` | `SearchModel` | `-` | The `searchModel` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `PagedResult<T>` | Returns a `PagedResult<T>` value. |

## Example

```csharp
using KamiSama.Extensions;
using KamiSama.Extensions.Paging;

var page = new[] { 1, 2, 3, 4 }.AsQueryable().MakePaged(SearchModel.FromPage(1, 2));
```

