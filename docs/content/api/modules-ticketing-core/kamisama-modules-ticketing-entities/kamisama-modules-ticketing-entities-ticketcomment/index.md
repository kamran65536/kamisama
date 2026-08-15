# TicketComment

<a id="ticketcomment"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Entities/TicketComment.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Entities/TicketComment.cs#L7)

Namespace: `KamiSama.Modules.Ticketing.Entities`

Kind: `Class`

## Description

EF Core comment belonging to one ticket, with caller-attributed side and author, 400-character text, timestamps, and attachment references. Provider migrations cascade its deletion to attachments.

## Declaration

```csharp
public class TicketComment
```

## Example

```csharp
var comment = new TicketComment
{
    Ticket = ticket,
    AuthorUserId = userId,
    Comment = "Additional details",
    Side = TicketCommentSide.User,
    CreatedAt = DateTime.UtcNow,
    UpdatedAt = DateTime.UtcNow
};
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [Attachments](property-attachments-25.md) | Gets or sets the external content references attached to the comment. Use it with the surrounding package APIs when composing application code. |
| [AuthorUserId](property-authoruserid-19.md) | Gets or sets the claimed author user identifier. Use it with the surrounding package APIs when composing application code. |
| [Comment](property-comment-14.md) | Gets or sets the required comment text, limited to 400 characters by the EF Core model. Use it with the surrounding package APIs when composing application code. |
| [CreatedAt](property-createdat-21.md) | Gets or sets the comment creation timestamp. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-10.md) | Gets or sets the comment identifier. Use it with the surrounding package APIs when composing application code. |
| [Side](property-side-17.md) | Gets or sets whether the comment belongs to the user or operator side. Use it with the surrounding package APIs when composing application code. |
| [Ticket](property-ticket-12.md) | Gets or sets the required owning-ticket navigation. Use it with the surrounding package APIs when composing application code. |
| [UpdatedAt](property-updatedat-23.md) | Gets or sets the latest comment update timestamp. Use it with the surrounding package APIs when composing application code. |

