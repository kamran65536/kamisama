# TicketSearchModel

<a id="ticketsearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L17)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Carries ticket paging, text, category, author, status, priority, and ordering criteria. Current Core ignores the category identifier and recognizes only `priority`, `status`, and `updatedat` ordering tokens.

## Declaration

```csharp
public record TicketSearchModel(int Page, int PageSize, string? Comment, Guid? TicketCategoryId, Guid? AuthorUserId, TicketStatus[]? Statuses, TicketPriority[]? Priorities, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L17)

Carries paging and optional ticket-list filters for text, category, author, status, priority, and ordering. Core currently ignores &lt;paramref name=&quot;TicketCategoryId&quot;/&gt; and recognizes `priority`, `status`, and `updatedat` ordering tokens.

```csharp
public record TicketSearchModel(int Page, int PageSize, string? Comment, Guid? TicketCategoryId, Guid? AuthorUserId, TicketStatus[]? Statuses, TicketPriority[]? Priorities, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The one-based page number, or the implementation-defined all-results value. |
| `PageSize` | `int` | `-` | The maximum number of rows in a page, or the implementation-defined all-results value. |
| `Comment` | `string?` | `-` | Optional case-insensitive text matched against ticket titles and comment bodies by Core. |
| `TicketCategoryId` | `Guid?` | `-` | An optional category identifier; the current Core repository does not apply it. |
| `AuthorUserId` | `Guid?` | `-` | An optional user identifier matched against ticket or comment authors by Core. |
| `Statuses` | `TicketStatus[]?` | `-` | Optional accepted ticket statuses. |
| `Priorities` | `TicketPriority[]?` | `-` | Optional accepted ticket priorities. |
| `OrderBy` | `string?` | `-` | An optional implementation-specific ordering token. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [All](property-all-23.md) | Gets or sets the shared mutable search model requesting all tickets without filters or explicit ordering. Replace it only when application-wide callers intentionally need different all-results defaults. |

