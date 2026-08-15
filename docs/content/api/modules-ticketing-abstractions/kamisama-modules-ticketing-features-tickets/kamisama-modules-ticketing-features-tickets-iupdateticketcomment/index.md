# IUpdateTicketComment

<a id="iupdateticketcomment"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Features.cs:35](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Features.cs#L35)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Interface`

## Description

Defines comment update through a method key plus a request that contains another comment identifier. Current Core uses only the request identifier, so callers must not assume the key selects or validates the target.

## Declaration

```csharp
public interface IUpdateTicketComment : IUpdateFeature<UpdateTicketCommentRequest, Guid>;
```

## Example

```csharp
await updateComment.UpdateAsync(commentId,
    new UpdateTicketCommentRequest(commentId, userId, "Corrected details."), cancellationToken);
// Current Core ignores the first commentId and uses the request value.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

