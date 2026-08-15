# MakePagedAsync<T>

[Back to IOrderedQueryableExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md)

Source: [src/Repositories.EntityFramework/IOrderedQueryableExtensions.cs:26](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/IOrderedQueryableExtensions.cs#L26)

Type: `KamiSama.Repositories.EntityFramework.IOrderedQueryableExtensions`

Kind: `Method`

## Description

Counts the complete query and materializes the requested page. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static async Task<PagedResult<T>> MakePagedAsync<T>(this IOrderedQueryable<T> query, SearchModel searchModel, CancellationToken cancellationToken);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `T` | The element type returned by the query. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `query (extension receiver)` | `IOrderedQueryable<T>` | `-` | An ordered EF6 query. Its ordering determines stable page boundaries. |
| `searchModel` | `SearchModel` | `-` | The one-based page number and page size; a page size of zero returns all items. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel list materialization but not the synchronous count. |

## Returns

| Type | Description |
| --- | --- |
| `Task<PagedResult<T>>` | A result containing the unpaged count and the requested items. |

## Remarks

The count executes synchronously and does not observe &lt;paramref name=&quot;cancellationToken&quot;/&gt;. The data query executes separately, so concurrent database changes can make the count and items inconsistent.

## Example

```csharp
using KamiSama.Extensions.Paging;
using KamiSama.Repositories.EntityFramework;

PagedResult<User> page = await query.OrderBy(user => user.Id)
    .MakePagedAsync(SearchModel.FromPage(1, 20), cancellationToken);
```

