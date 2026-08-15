# TicketListItemDto

<a id="ticketlistitemdto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:36](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L36)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Carries the ticket fields returned by list operations without category, comment, or attachment data. Use a find operation when the complete aggregate is required.

## Declaration

```csharp
public record TicketListItemDto(Guid Id, Guid AuthorUserId, string Title, TicketStatus Status, TicketPriority Priority, DateTime CreatedAt, DateTime UpdatedAt);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L36)

Carries the ticket fields returned by list operations without category, comment, or attachment data. Use a find operation when the complete aggregate is required.

```csharp
public record TicketListItemDto(Guid Id, Guid AuthorUserId, string Title, TicketStatus Status, TicketPriority Priority, DateTime CreatedAt, DateTime UpdatedAt);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The ticket identifier. |
| `AuthorUserId` | `Guid` | `-` | The identifier of the user who opened the ticket. |
| `Title` | `string` | `-` | The ticket title. |
| `Status` | `TicketStatus` | `-` | The current workflow status. |
| `Priority` | `TicketPriority` | `-` | The current urgency. |
| `CreatedAt` | `DateTime` | `-` | The ticket creation timestamp. |
| `UpdatedAt` | `DateTime` | `-` | The ticket&apos;s latest update timestamp. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

