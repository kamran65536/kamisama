# TicketSearchModel

<a id="ticketsearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L5)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Provides the `TicketSearchModel` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record TicketSearchModel(int Page, int PageSize, string? Comment, Guid? TicketCategoryId, Guid? AuthorUserId, TicketStatus[]? Statuses, TicketPriority[]? Priorities, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L5)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record TicketSearchModel(int Page, int PageSize, string? Comment, Guid? TicketCategoryId, Guid? AuthorUserId, TicketStatus[]? Statuses, TicketPriority[]? Priorities, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The `Page` value passed to this member. |
| `PageSize` | `int` | `-` | The `PageSize` value passed to this member. |
| `Comment` | `string?` | `-` | The `Comment` value passed to this member. |
| `TicketCategoryId` | `Guid?` | `-` | The `TicketCategoryId` value passed to this member. |
| `AuthorUserId` | `Guid?` | `-` | The `AuthorUserId` value passed to this member. |
| `Statuses` | `TicketStatus[]?` | `-` | The `Statuses` value passed to this member. |
| `Priorities` | `TicketPriority[]?` | `-` | The `Priorities` value passed to this member. |
| `OrderBy` | `string?` | `-` | The `OrderBy` value passed to this member. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [All](property-all-7.md) | Exposes the `All` value on `TicketSearchModel`. Read or set it as part of configuring or using the type. |

