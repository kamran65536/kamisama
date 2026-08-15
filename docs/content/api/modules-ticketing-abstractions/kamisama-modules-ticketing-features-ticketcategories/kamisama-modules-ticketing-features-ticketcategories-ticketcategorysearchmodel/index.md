# TicketCategorySearchModel

<a id="ticketcategorysearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs#L11)

Namespace: `KamiSama.Modules.Ticketing.Features.TicketCategories`

Kind: `Record`

## Description

Carries paging, optional name filtering, and ordering for ticket-category lists. Core performs a case-insensitive exact name comparison and recognizes `id`, `name`, `createdat`, and `updatedat` ordering tokens.

## Declaration

```csharp
public record TicketCategorySearchModel(int Page, int PageSize, string? Name, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs#L11)

Carries paging, optional name filtering, and ordering for ticket-category lists. Core performs a case-insensitive exact name comparison and recognizes `id`, `name`, `createdat`, and `updatedat` ordering tokens.

```csharp
public record TicketCategorySearchModel(int Page, int PageSize, string? Name, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The one-based page number, or the implementation-defined all-results value. |
| `PageSize` | `int` | `-` | The maximum number of rows in a page, or the implementation-defined all-results value. |
| `Name` | `string?` | `-` | An optional category name filter. |
| `OrderBy` | `string?` | `-` | An optional implementation-specific ordering token. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [All](property-all-17.md) | Gets or sets the shared mutable search model requesting all categories without a name or ordering filter. Replace it only when application-wide callers intentionally need different all-results defaults. |

