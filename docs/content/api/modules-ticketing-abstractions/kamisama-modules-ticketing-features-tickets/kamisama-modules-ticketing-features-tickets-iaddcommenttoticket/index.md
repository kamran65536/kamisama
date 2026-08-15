# IAddCommentToTicket

<a id="iaddcommenttoticket"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Features.cs:30](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Features.cs#L30)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Interface`

## Description

Adds a comment and optional attachments to an existing ticket. Implementations determine side and author authorization.

## Declaration

```csharp
public interface IAddCommentToTicket : IAddFeature<AddTicketCommentRequest, TicketDto>;
```

## Example

```csharp
TicketDto ticket = await addComment.AddAsync(new AddTicketCommentRequest(
    ticketId, userId, TicketCommentSide.User, "This still occurs.", []), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

