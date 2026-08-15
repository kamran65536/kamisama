# IQueryableExtensions

<a id="iqueryableextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFrameworkCore/IQueryableExtensions.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/IQueryableExtensions.cs#L12)

Namespace: `KamiSama.Repositories.EntityFrameworkCore`

Kind: `Class`

## Description

Pages EF Core queries using caller-supplied ordering. It synchronously counts all matches before cancellable asynchronous materialization, using two separate database queries.

## Declaration

```csharp
public static class IQueryableExtensions
```

## Example

```csharp
using KamiSama.Extensions.Paging;
using KamiSama.Repositories.EntityFrameworkCore;

PagedResult<User> page = await dbContext.Users
    .AsNoTracking()
    .OrderBy(user => user.Id)
    .MakePagedAsync(SearchModel.FromPage(1, 20), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [MakePagedAsync<T>](method-makepagedasync-t-27.md) | Counts the complete query and materializes the requested page. Use it with the surrounding package APIs when composing application code. |

