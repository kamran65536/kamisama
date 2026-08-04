# AddAttachmentToTicketCommentRequest

<a id="addattachmenttoticketcommentrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L17)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Provides the `AddAttachmentToTicketCommentRequest` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record AddAttachmentToTicketCommentRequest(Guid CommentId, Guid AuthorUserId, List<Guid> AttachmentContentIds);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L17)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record AddAttachmentToTicketCommentRequest(Guid CommentId, Guid AuthorUserId, List<Guid> AttachmentContentIds);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `CommentId` | `Guid` | `-` | The `CommentId` value passed to this member. |
| `AuthorUserId` | `Guid` | `-` | The `AuthorUserId` value passed to this member. |
| `AttachmentContentIds` | `List<Guid>` | `-` | The `AttachmentContentIds` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

