# TicketDto

<a id="ticketdto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L12)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Provides the `TicketDto` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record TicketDto(Guid Id, Guid AuthorUserId, TicketCategoryListItemDto Category, string Title, TicketStatus Status, TicketPriority Priority, List<TicketCommentDto> Comments, DateTime CreatedAt, DateTime UpdatedAt);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L12)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record TicketDto(Guid Id, Guid AuthorUserId, TicketCategoryListItemDto Category, string Title, TicketStatus Status, TicketPriority Priority, List<TicketCommentDto> Comments, DateTime CreatedAt, DateTime UpdatedAt);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The `Id` value passed to this member. |
| `AuthorUserId` | `Guid` | `-` | The `AuthorUserId` value passed to this member. |
| `Category` | `TicketCategoryListItemDto` | `-` | The `Category` value passed to this member. |
| `Title` | `string` | `-` | The `Title` value passed to this member. |
| `Status` | `TicketStatus` | `-` | The `Status` value passed to this member. |
| `Priority` | `TicketPriority` | `-` | The `Priority` value passed to this member. |
| `Comments` | `List<TicketCommentDto>` | `-` | The `Comments` value passed to this member. |
| `CreatedAt` | `DateTime` | `-` | The `CreatedAt` value passed to this member. |
| `UpdatedAt` | `DateTime` | `-` | The `UpdatedAt` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

