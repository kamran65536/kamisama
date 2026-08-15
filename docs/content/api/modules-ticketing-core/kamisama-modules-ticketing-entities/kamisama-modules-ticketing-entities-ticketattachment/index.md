# TicketAttachment

<a id="ticketattachment"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Entities/TicketAttachment.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Entities/TicketAttachment.cs#L7)

Namespace: `KamiSama.Modules.Ticketing.Entities`

Kind: `Class`

## Description

EF Core reference from a ticket comment to an external content identifier. It stores no content bytes or metadata and is cascade-deleted with its comment.

## Declaration

```csharp
public class TicketAttachment
```

## Example

```csharp
var attachment = new TicketAttachment
{
    Comment = comment,
    ContentId = contentId,
    AuthorUserId = userId
};
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [AuthorUserId](property-authoruserid-16.md) | Gets or sets the identifier of the user who attached the content. Use it with the surrounding package APIs when composing application code. |
| [Comment](property-comment-12.md) | Gets or sets the required owning-comment navigation. Use it with the surrounding package APIs when composing application code. |
| [ContentId](property-contentid-14.md) | Gets or sets the external content identifier. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-10.md) | Gets or sets the ticket attachment identifier. Use it with the surrounding package APIs when composing application code. |

