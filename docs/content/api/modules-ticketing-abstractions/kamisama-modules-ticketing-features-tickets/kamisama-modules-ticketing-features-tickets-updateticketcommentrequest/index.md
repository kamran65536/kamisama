# UpdateTicketCommentRequest

<a id="updateticketcommentrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:89](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L89)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Carries the actual comment identifier, claimed author identifier, and replacement text used by Core. Core ignores the separate update-method key and authorizes only by equality with the stored author identifier.

## Declaration

```csharp
public record UpdateTicketCommentRequest(Guid CommentId, Guid AuthorUserId, string Comment);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L89)

Supplies the comment identifier, claimed author, and replacement text for a comment update. Current Core uses &lt;paramref name=&quot;CommentId&quot;/&gt; instead of the separate update-method key and authorizes only by identifier equality.

```csharp
public record UpdateTicketCommentRequest(Guid CommentId, Guid AuthorUserId, string Comment);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `CommentId` | `Guid` | `-` | The identifier of the comment to update. |
| `AuthorUserId` | `Guid` | `-` | The claimed author identifier used by Core&apos;s ownership check. |
| `Comment` | `string` | `-` | The replacement comment text. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

