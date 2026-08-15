# IAddAttachmentToTicketComment

<a id="iaddattachmenttoticketcomment"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Features.cs:40](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Features.cs#L40)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Interface`

## Description

Adds content references to an existing ticket comment. Implementations determine ownership and duplicate-content behavior.

## Declaration

```csharp
public interface IAddAttachmentToTicketComment : IAddFeature<AddAttachmentToTicketCommentRequest, TicketDto>;
```

## Example

```csharp
TicketDto ticket = await addAttachment.AddAsync(
    new AddAttachmentToTicketCommentRequest(commentId, userId, [contentId]),
    cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

