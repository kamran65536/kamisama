# AddTicketCommentRequest

<a id="addticketcommentrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:107](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L107)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Supplies a ticket identifier and the data for a new comment with optional attachment references. Current Core accepts the requested side and author without checking ticket editability or caller identity.

## Declaration

```csharp
public record AddTicketCommentRequest(Guid TicketId, Guid AuthorUserId, TicketCommentSide Side, string Comment, List<Guid> AttachmentContentIds);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L107)

Supplies a ticket identifier and the data for a new comment with optional attachment references. Current Core accepts the requested side and author without checking ticket editability or caller identity.

```csharp
public record AddTicketCommentRequest(Guid TicketId, Guid AuthorUserId, TicketCommentSide Side, string Comment, List<Guid> AttachmentContentIds);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `TicketId` | `Guid` | `-` | The identifier of the ticket receiving the comment. |
| `AuthorUserId` | `Guid` | `-` | The claimed comment author identifier. |
| `Side` | `TicketCommentSide` | `-` | The requested user or operator side. |
| `Comment` | `string` | `-` | The comment text. |
| `AttachmentContentIds` | `List<Guid>` | `-` | External content identifiers to attach to the comment. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

