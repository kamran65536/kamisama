# MakePagedAsync<T>

[Back to IQueryableExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/IQueryableExtensions.cs:27](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/IQueryableExtensions.cs#L27)

Type: `KamiSama.Repositories.EntityFrameworkCore.IQueryableExtensions`

Kind: `Method`

## Description

Counts the complete query and materializes the requested page. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static async Task<PagedResult<T>> MakePagedAsync<T>(this IQueryable<T> query, SearchModel searchModel, CancellationToken cancellationToken);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `T` | The element type returned by the query. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `query (extension receiver)` | `IQueryable<T>` | `-` | The EF Core query to page. Apply a deterministic ordering before calling this method. |
| `searchModel` | `SearchModel` | `-` | The one-based page number and page size; a page size of zero returns all items. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel list materialization but not the synchronous count. |

## Returns

| Type | Description |
| --- | --- |
| `Task<PagedResult<T>>` | A result containing the unpaged count and the requested items. |

## Remarks

The method does not add ordering. The count executes synchronously and does not observe &lt;paramref name=&quot;cancellationToken&quot;/&gt;. Count and materialization are separate queries, so concurrent changes can make the count and items inconsistent.

## Example

```csharp
using KamiSama.Extensions.Paging;
using KamiSama.Repositories.EntityFrameworkCore;

PagedResult<User> page = await query.OrderBy(user => user.Id)
    .MakePagedAsync(SearchModel.FromPage(1, 20), cancellationToken);
```

