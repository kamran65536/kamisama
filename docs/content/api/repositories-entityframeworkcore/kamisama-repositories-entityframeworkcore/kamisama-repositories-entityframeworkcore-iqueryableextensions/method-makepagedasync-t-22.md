# MakePagedAsync<T>

[Back to IQueryableExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/IQueryableExtensions.cs:22](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/IQueryableExtensions.cs#L22)

Type: `KamiSama.Repositories.EntityFrameworkCore.IQueryableExtensions`

Kind: `Method`

## Description

Makes the query paged, used for user interface and apis paging. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static async Task<PagedResult<T>> MakePagedAsync<T>(this IQueryable<T> query, SearchModel searchModel, CancellationToken cancellationToken);
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
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<PagedResult<T>>` | Returns a `Task<PagedResult<T>>` value. |

## Example

```csharp
var query = GetDbContext().SampleEntities.OrderBy(x => x.Id);

var paged = await query.MakePagedAsync(SearchModel.All, CancellationToken.None);
```

