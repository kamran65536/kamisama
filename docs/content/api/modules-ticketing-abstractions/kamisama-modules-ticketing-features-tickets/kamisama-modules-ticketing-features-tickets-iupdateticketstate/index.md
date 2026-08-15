# IUpdateTicketState

<a id="iupdateticketstate"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Features.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Features.cs#L20)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Interface`

## Description

Defines keyed replacement of a ticket's title, status, and priority. Core validates the requested workflow transition before changing or saving the tracked ticket and reports invalid transitions as HTTP 409 conflicts.

## Declaration

```csharp
public interface IUpdateTicketState : IUpdateFeature<UpdateTicketStateRequest, Guid>;
```

## Example

```csharp
// Open and reopened tickets can transition to resolved.
await updateTicket.UpdateAsync(ticketId,
    new UpdateTicketStateRequest("Cannot sign in", TicketStatus.Resolved, TicketPriority.High),
    cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

