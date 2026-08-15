# TicketDto

<a id="ticketdto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:70](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L70)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Carries a complete ticket aggregate with category, comments, and attachment references. Core mapping relies on the corresponding EF Core navigations being available.

## Declaration

```csharp
public record TicketDto(Guid Id, Guid AuthorUserId, TicketCategoryListItemDto Category, string Title, TicketStatus Status, TicketPriority Priority, List<TicketCommentDto> Comments, DateTime CreatedAt, DateTime UpdatedAt);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L70)

Carries a complete ticket aggregate with category, comments, and attachment references. Core mapping relies on the corresponding EF Core navigations being available.

```csharp
public record TicketDto(Guid Id, Guid AuthorUserId, TicketCategoryListItemDto Category, string Title, TicketStatus Status, TicketPriority Priority, List<TicketCommentDto> Comments, DateTime CreatedAt, DateTime UpdatedAt);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The ticket identifier. |
| `AuthorUserId` | `Guid` | `-` | The identifier of the user who opened the ticket. |
| `Category` | `TicketCategoryListItemDto` | `-` | The ticket category. |
| `Title` | `string` | `-` | The ticket title. |
| `Status` | `TicketStatus` | `-` | The current workflow status. |
| `Priority` | `TicketPriority` | `-` | The current urgency. |
| `Comments` | `List<TicketCommentDto>` | `-` | The ticket comments and their attachment references. |
| `CreatedAt` | `DateTime` | `-` | The ticket creation timestamp. |
| `UpdatedAt` | `DateTime` | `-` | The ticket&apos;s latest update timestamp. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

