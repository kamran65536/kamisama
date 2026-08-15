# TicketCommentDto

<a id="ticketcommentdto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:56](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L56)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Carries one ticket comment, its author and side, attachment references, and timestamps. Attachment values contain external content identifiers rather than content bytes.

## Declaration

```csharp
public record TicketCommentDto(Guid Id, Guid AuthorUserId, string Comment, TicketCommentSide Side, List<TicketAttachmentDto> Attachments, DateTime CreatedAt, DateTime UpdatedAt);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L56)

Carries one ticket comment, its author and side, attachment references, and timestamps. Attachment values contain external content identifiers rather than content bytes.

```csharp
public record TicketCommentDto(Guid Id, Guid AuthorUserId, string Comment, TicketCommentSide Side, List<TicketAttachmentDto> Attachments, DateTime CreatedAt, DateTime UpdatedAt);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The comment identifier. |
| `AuthorUserId` | `Guid` | `-` | The comment author&apos;s user identifier. |
| `Comment` | `string` | `-` | The comment text. |
| `Side` | `TicketCommentSide` | `-` | Whether the comment belongs to the user or operator side. |
| `Attachments` | `List<TicketAttachmentDto>` | `-` | The attachment references associated with the comment. |
| `CreatedAt` | `DateTime` | `-` | The comment creation timestamp. |
| `UpdatedAt` | `DateTime` | `-` | The comment&apos;s latest update timestamp. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

