# AddAttachmentToTicketCommentRequest

<a id="addattachmenttoticketcommentrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:115](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L115)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Supplies an existing comment, claimed author, and external content identifiers to attach. Core requires author-id equality and rejects content identifiers already present on that comment.

## Declaration

```csharp
public record AddAttachmentToTicketCommentRequest(Guid CommentId, Guid AuthorUserId, List<Guid> AttachmentContentIds);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L115)

Supplies an existing comment, claimed author, and external content identifiers to attach. Core requires author-id equality and rejects content identifiers already present on that comment.

```csharp
public record AddAttachmentToTicketCommentRequest(Guid CommentId, Guid AuthorUserId, List<Guid> AttachmentContentIds);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `CommentId` | `Guid` | `-` | The identifier of the comment receiving attachments. |
| `AuthorUserId` | `Guid` | `-` | The claimed author identifier used by Core&apos;s ownership check. |
| `AttachmentContentIds` | `List<Guid>` | `-` | External content identifiers to add. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

