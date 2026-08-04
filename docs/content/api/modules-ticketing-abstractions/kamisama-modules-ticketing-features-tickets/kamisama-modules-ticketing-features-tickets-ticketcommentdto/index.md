# TicketCommentDto

<a id="ticketcommentdto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L11)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Provides the `TicketCommentDto` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record TicketCommentDto(Guid Id, Guid AuthorUserId, string Comment, TicketCommentSide Side, List<TicketAttachmentDto> Attachments, DateTime CreatedAt, DateTime UpdatedAt);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L11)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record TicketCommentDto(Guid Id, Guid AuthorUserId, string Comment, TicketCommentSide Side, List<TicketAttachmentDto> Attachments, DateTime CreatedAt, DateTime UpdatedAt);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The `Id` value passed to this member. |
| `AuthorUserId` | `Guid` | `-` | The `AuthorUserId` value passed to this member. |
| `Comment` | `string` | `-` | The `Comment` value passed to this member. |
| `Side` | `TicketCommentSide` | `-` | The `Side` value passed to this member. |
| `Attachments` | `List<TicketAttachmentDto>` | `-` | The `Attachments` value passed to this member. |
| `CreatedAt` | `DateTime` | `-` | The `CreatedAt` value passed to this member. |
| `UpdatedAt` | `DateTime` | `-` | The `UpdatedAt` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

